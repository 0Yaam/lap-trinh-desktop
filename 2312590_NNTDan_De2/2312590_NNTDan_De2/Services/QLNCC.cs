using _2312590_NNTDan_De2.Object;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312590_NNTDan_De2
{
    public class QLNCC
    {
        private readonly List<NhaCungCap> dsncc = new List<NhaCungCap>();

        public List<NhaCungCap> DocFile(string filename)
        {
            var list = new List<NhaCungCap>();

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

                        string maNCC = parts[0].Trim();
                        string ten = parts[1].Trim();
                        string diaChi = parts[2].Trim();
                        string sdt = parts[3].Trim();
                        string moTa = parts[4].Trim();

                        var ncc = new NhaCungCap(maNCC, ten, diaChi, sdt, moTa);
                        list.Add(ncc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message, "Thông báo");
            }

            return list;
        }

        public void GhiFileTXT(string filename, NhaCungCap ncc)
        {
            string line = $"{ncc.MaNCC}|{ncc.TenNCC}|{ncc.DiaChi}|{ncc.SDT}|{ncc.MoTa}";
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


        public void ThemNCC(NhaCungCap ncc) => dsncc.Add(ncc);


        public bool CapNhatNCC(string filename, NhaCungCap nccMoi)
        {
            var list = DocFile(filename);
            int idx = list.FindIndex(ncc => ncc.MaNCC.Equals(nccMoi.MaNCC, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) return false;

            list[idx] = nccMoi;

            using (var sw = new StreamWriter(filename, append: false))
            {
                foreach (var ncc in list)
                {
                    sw.WriteLine($"{ncc.MaNCC}|{ncc.TenNCC}|{ncc.DiaChi}|{ncc.SDT}|{ncc.MoTa}");
                }
            }
            return true;
        }


        public void XoaNCC(string filename, List<string> listNCC)
        {
            var newList = DocFile(filename)
                .Where(ncc => !listNCC.Contains(ncc.MaNCC, StringComparer.OrdinalIgnoreCase))
                .ToList();

            try
            {
                File.WriteAllLines(filename, newList.Select(ncc =>
                    $"{ncc.MaNCC}|{ncc.TenNCC}|{ncc.DiaChi}|{ncc.SDT}|{ncc.MoTa}"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xoá nhiều: " + ex.Message, "Thông báo");
            }
        }



        public bool KiemTraTrungNCCTrongFile(string filename, string mancc)
        {
            return DocFile(filename).Any(s => s.MaNCC.Equals(mancc, StringComparison.OrdinalIgnoreCase));
        }







    }
}
