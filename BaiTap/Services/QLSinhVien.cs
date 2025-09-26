using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap
{
    public class QLSinhVien
    {
        List<SinhVien> dssv = new List<SinhVien>();
        public List<SinhVien> DocFile(string filename)
        {

            List<SinhVien> List = new List<SinhVien>();
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string mssv = parts[0];
                string hotenlot = parts[1];
                string ten = parts[2];
                DateTime ngaysinh = DateTime.ParseExact(
                        parts[3].Trim(),
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    );
                bool gioitinh = parts[4] == "1" ? true : false;
                string lop = parts[5];
                string cmnd = parts[6];
                string sdt = parts[7];
                string diachi = parts[8];
                SinhVien sv = new SinhVien(mssv, hotenlot, ten, ngaysinh, gioitinh, lop, cmnd, sdt, diachi);
                List.Add(sv);
            }
            sr.Close();
            return List;
        }


        public void GhiFile(string filename, SinhVien sv)
        {
            string gioitinh = sv.GioiTinh ? "1" : "0";
            string line = $"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{gioitinh}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}";

            // Ghi thêm 1 dòng mới vào cuối file
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(line);   // <-- mỗi lần gọi sẽ tự xuống dòng
            }
        }

        public void ThemSV(SinhVien sv) => dssv.Add(sv);

        public void KiemTraTrungMSSV(string mssv)
        {
            foreach (var sv in dssv)
            {
                if (sv.MSSV == mssv)
                {
                    MessageBox.Show("MSSV đã tồn tại!","Thông báo");
                }
            }
            return;
        }



        public bool CapNhatSV(string filename, SinhVien svMoi)
        {
            var list = DocFile(filename);
            int idx = list.FindIndex(s => s.MSSV.Equals(svMoi.MSSV, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) return false;

            list[idx] = svMoi;

            using (var sw = new StreamWriter(filename, append: false)) // ghi đè toàn bộ
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
            int count = list.Count;

            list = list.Where(sv => !!sv.MSSV.Equals(mssv)).ToList();
            if (list.Count == count)
                return false;

            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                foreach (var sv in list)
                {
                    string gt = sv.GioiTinh ? "1" : "0";
                    sw.WriteLine($"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{gt}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}");
                }
            }
            return true;
        }

        public void XoaSV(string filename, List<string> listMSSV)
        {
            var newList = DocFile(filename)
                .Where(sv => !listMSSV.Contains(sv.MSSV))   // lọc bỏ MSSV cần xoá
                .ToList();

            File.WriteAllLines(filename, newList.Select(sv =>
                $"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{(sv.GioiTinh ? "1" : "0")}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}"
            ));
        }


        public void LuuThuCong(string filename, List<SinhVien> dssv)
        {
            using (var sw = new StreamWriter(filename, false)) 
            {
                foreach (var sv in dssv)
                {
                    string gt = sv.GioiTinh ? "1" : "0";
                    sw.WriteLine($"{sv.MSSV}|{sv.HoTenLot}|{sv.Ten}|{sv.NgaySinh:dd/MM/yyyy}|{gt}|{sv.Lop}|{sv.CMND}|{sv.SDT}|{sv.DiaChi}");
                }
            }
        }






        //------------------------------------------------------
    }
}