using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaiTap
{
    public class QLSinhVien
    {
        private readonly List<SinhVien> dssv = new List<SinhVien>();

        public List<SinhVien> DocFile(string filename)
        {
            var list = new List<SinhVien>();

            if (!File.Exists(filename))
                return list;

            try
            {
                using (var sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var parts = line.Split('|');
                        if (parts.Length < 9) continue; // bỏ dòng lỗi

                        string mssv = parts[0].Trim();
                        string hotenlot = parts[1].Trim();
                        string ten = parts[2].Trim();
                        if (!DateTime.TryParseExact(parts[3].Trim(), "dd/MM/yyyy",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out var ngaysinh))
                            continue;

                        bool gioitinh = parts[4].Trim() == "1";
                        string lop = parts[5].Trim();
                        string cmnd = parts[6].Trim();
                        string sdt = parts[7].Trim();
                        string diachi = parts[8].Trim();

                        var sv = new SinhVien(mssv, hotenlot, ten, ngaysinh, gioitinh, lop, cmnd, sdt, diachi);
                        list.Add(sv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message, "Thông báo");
            }

            return list;
        }

        public void GhiFile(string filename, SinhVien sv)
        {
            string gioitinh = sv.GioiTinh ? "1" : "0";
            string line = $"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{gioitinh}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}";
            try
            {
                using (var sw = new StreamWriter(filename, append: true))
                    sw.WriteLine(line);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message, "Thông báo");
            }
        }

        public void ThemSV(SinhVien sv) => dssv.Add(sv);

        // Trả về true nếu trùng
        public bool KiemTraTrungMSSVTrongFile(string filename, string mssv)
        {
            return DocFile(filename).Any(s => s.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase));
        }

        public bool CapNhatSV(string filename, SinhVien svMoi)
        {
            var list = DocFile(filename);
            int idx = list.FindIndex(s => s.MSSV.Equals(svMoi.MSSV, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) return false;

            list[idx] = svMoi;

                using (var sw = new StreamWriter(filename, append: false))
                {
                    foreach (var sv in list)
                    {
                        string gioitinh = sv.GioiTinh ? "1" : "0";
                        sw.WriteLine($"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{gioitinh}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}");
                    }
                }
                return true;
        }

        public bool XoaSV(string filename, string mssv)
        {
            var list = DocFile(filename);
            int countOld = list.Count;

            // SỬA LỖI: điều kiện đúng là giữ lại những sv mà MSSV KHÁC mssv
            list = list.Where(sv => !sv.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase)).ToList();

            if (list.Count == countOld) return false;

            try
            {
                using (var sw = new StreamWriter(filename, append: false))
                {
                    foreach (var sv in list)
                    {
                        string gt = sv.GioiTinh ? "1" : "0";
                        sw.WriteLine($"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{gt}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xoá file: " + ex.Message, "Thông báo");
                return false;
            }
        }

        public void XoaSV(string filename, List<string> listMSSV)
        {
            var newList = DocFile(filename)
                .Where(sv => !listMSSV.Contains(sv.MSSV, StringComparer.OrdinalIgnoreCase))
                .ToList();

            try
            {
                File.WriteAllLines(filename, newList.Select(sv =>
                    $"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{(sv.GioiTinh ? "1" : "0")}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}"
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xoá nhiều: " + ex.Message, "Thông báo");
            }
        }

        public void LuuThuCong(string filename, List<SinhVien> list)
        {
            try
            {
                using (var sw = new StreamWriter(filename, false))
                {
                    foreach (var sv in list)
                    {
                        string gt = sv.GioiTinh ? "1" : "0";
                        sw.WriteLine($"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{gt}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message, "Thông báo");
            }
        }
    }
}
