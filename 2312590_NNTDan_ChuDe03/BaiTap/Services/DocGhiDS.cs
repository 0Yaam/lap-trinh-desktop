using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
// JSON: dùng System.Text.Json cho C# 7.3 (không cần JsonConvert)
using System.Text.Json;

namespace BaiTap.Services
{
    public interface IDocGhi
    {
        List<SinhVien> Doc(string path);
        void Ghi(string path, List<SinhVien> list);
        void Them(string path, SinhVien sv);
    }

    public static class DocGhiDS
    {
        public static IDocGhi ChonTheoFile(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            switch (ext)
            {
                case ".txt": return new DocGhiTxt();
                case ".xml": return new DocGhiXml();
                case ".json": return new DocGhiJson();
                default:
                    throw new NotSupportedException("Không hỗ trợ định dạng: " + ext);
            }
        }
    }

    // ---------------- TXT ----------------
    public class DocGhiTxt : IDocGhi
    {
        private const string DateFmt = "dd/MM/yyyy";

        public List<SinhVien> Doc(string path)
        {
            var list = new List<SinhVien>();
            if (!File.Exists(path)) return list;

            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');
                if (parts.Length < 9) continue;

                DateTime dob;
                if (!DateTime.TryParseExact(parts[3].Trim(), DateFmt, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dob))
                    continue;

                var sv = new SinhVien
                {
                    MSSV = parts[0].Trim(),
                    HoTenLot = parts[1].Trim(),
                    Ten = parts[2].Trim(),
                    NgaySinh = dob,
                    GioiTinh = parts[4].Trim() == "1",
                    Lop = parts[5].Trim(),
                    CMND = parts[6].Trim(),
                    SDT = parts[7].Trim(),
                    DiaChi = parts[8].Trim()
                };
                list.Add(sv);
            }
            return list;
        }

        public void Ghi(string path, List<SinhVien> list)
        {
            var lines = list.Select(sv =>
                string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                    sv.MSSV,
                    sv.HoTenLot,
                    sv.Ten,
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.GioiTinh ? "1" : "0",
                    sv.Lop,
                    sv.CMND,
                    sv.SDT,
                    sv.DiaChi
                ));
            File.WriteAllLines(path, lines);
        }

        public void Them(string path, SinhVien sv)
        {
            var line = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                sv.MSSV,
                sv.HoTenLot,
                sv.Ten,
                sv.NgaySinh.ToString("dd/MM/yyyy"),
                sv.GioiTinh ? "1" : "0",
                sv.Lop,
                sv.CMND,
                sv.SDT,
                sv.DiaChi
            );
            File.AppendAllLines(path, new[] { line });
        }
    }

    // ---------------- XML ----------------
    [XmlRoot("Students")]
    public class StudentsWrapper
    {
        [XmlElement("Student")]
        public List<SinhVien> Items { get; set; }

        public StudentsWrapper()
        {
            Items = new List<SinhVien>();
        }
    }

    public class DocGhiXml : IDocGhi
    {
        public List<SinhVien> Doc(string path)
        {
            if (!File.Exists(path)) return new List<SinhVien>();
            var ser = new XmlSerializer(typeof(StudentsWrapper));
            using (var fs = File.OpenRead(path))
            {
                var dto = (StudentsWrapper)ser.Deserialize(fs);
                return dto != null && dto.Items != null ? dto.Items : new List<SinhVien>();
            }
        }

        public void Ghi(string path, List<SinhVien> list)
        {
            var ser = new XmlSerializer(typeof(StudentsWrapper));
            using (var fs = File.Create(path))
            {
                var dto = new StudentsWrapper { Items = list ?? new List<SinhVien>() };
                ser.Serialize(fs, dto);
            }
        }

        public void Them(string path, SinhVien sv)
        {
            var all = Doc(path);
            all.Add(sv);
            Ghi(path, all);
        }
    }

    // ---------------- JSON (System.Text.Json) ----------------
    public class DocGhiJson : IDocGhi
    {
        private static readonly JsonSerializerOptions _opts = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public List<SinhVien> Doc(string path)
        {
            if (!File.Exists(path)) return new List<SinhVien>();
            var json = File.ReadAllText(path);
            var list = JsonSerializer.Deserialize<List<SinhVien>>(json, _opts);
            return list ?? new List<SinhVien>();
        }

        public void Ghi(string path, List<SinhVien> list)
        {
            var json = JsonSerializer.Serialize(list ?? new List<SinhVien>(), _opts);
            File.WriteAllText(path, json);
        }

        public void Them(string path, SinhVien sv)
        {
            var all = Doc(path);
            all.Add(sv);
            Ghi(path, all);
        }
    }
}
