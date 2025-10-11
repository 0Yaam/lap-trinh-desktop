using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using _2312590_NNTDan_De2.Object;

namespace _2312590_NNTDan_De2.Services
{
    public interface IDocGhi
    {
        List<NhaCungCap> Doc(string path);
        void Ghi(string path, List<NhaCungCap> list);
        void Them(string path, NhaCungCap ncc);
    }

    public static class DocGhiDS
    {
        public static IDocGhi ChonTheoFile(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            switch (ext)
            {
                case ".txt": return new DocGhiTxt();
                default:
                    throw new NotSupportedException("Không hỗ trợ định dạng: " + ext);
            }
        }
    }

    public class DocGhiTxt : IDocGhi
    {
        private const string DateFmt = "dd/MM/yyyy";

        public List<NhaCungCap> Doc(string path)
        {
            var list = new List<NhaCungCap>();
            if (!File.Exists(path)) return list;

            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');

                var ncc = new NhaCungCap
                {
                    MaNCC = parts[0].Trim(),
                    TenNCC = parts[1].Trim(),
                    DiaChi = parts[2].Trim(),
                    SDT = parts[3].Trim(),
                    MoTa = parts[4].Trim(),
                };
                list.Add(ncc);
            }
            return list;
        }

        public void Ghi(string path, List<NhaCungCap> list)
        {
            var lines = list.Select(ncc =>
                string.Format("{0}|{1}|{2}|{3}|{4}",
                    ncc.MaNCC,
                    ncc.TenNCC, ncc.DiaChi, ncc.SDT, ncc.MoTa
                ));
            File.WriteAllLines(path, lines);
        }

        public void Them(string path, NhaCungCap ncc)
        {
        }
    }



}
