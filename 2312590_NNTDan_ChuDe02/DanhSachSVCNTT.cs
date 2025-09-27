using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public class DanhSachSVCNTT
    {
        public List<SVCNTT> danhSach;
        public DanhSachSVCNTT()
        {
            danhSach = new List<SVCNTT>();
        }
        public void Them(SVCNTT sv)
        {
            danhSach.Add(sv);
        }
        public void NhapCoDinh5SinhVien()
        {
            // Sinh viên 1
            Them(new SVCNTT("231101", "Nguyễn Văn A", true, "0912345678", "123 Đường ABC", "nva@gmail.com", "CTK43", "SinhVien1.png", new DateTime(2005, 1, 1)));

            // Sinh viên 2
            Them(new SVCNTT("231102", "Trần Thị B", false, "0987654321", "456 Đường XYZ", "ttb@gmail.com", "CTK43", "SinhVien2.png", new DateTime(2005, 2, 2)));

            // Sinh viên 3
            Them(new SVCNTT("231103", "Lê Văn C", true, "0901122334", "789 Đường DEF", "lvc@gmail.com", "CTK45", "SinhVien3.png", new DateTime(2005, 3, 3)));

            // Sinh viên 4
            Them(new SVCNTT("231104", "Phạm Thị D", false, "0902233445", "101 Đường GHI", "ptd@gmail.com", "CTK43", "SinhVien4.png", new DateTime(2005, 4, 4)));

            // Sinh viên 5
            Them(new SVCNTT("231105", "Vũ Văn E", true, "0903344556", "202 Đường JKL", "vve@gmail.com", "CTK44", "SinhVien5.png", new DateTime(2005, 5, 5)));
        }

        public void NhapTuFile(string tenFile)
        {
            if(File.Exists(tenFile))
            {

            }
            using (StreamReader sr=new StreamReader(tenFile))
            {
                string line;
                while((line=sr.ReadLine())!=null)
                {
                    string[] part=line.Split('|');
                    if (part.Length==9)
                    {
                        this.Them(new SVCNTT(
                            part[0], // MSSV
                            part[1], // HoTen
                            bool.Parse(part[2]), // GioiTinh
                            part[3], // SDT
                            part[4], // DiaChi
                            part[5], // Email
                            part[6], // Lop
                            part[7], // Hinh
                            DateTime.Parse(part[8]) // NgaySinh
                        ));
                    }
                };
            }
        }
        public List<SVCNTT> LayDanhSach()
        {
            return danhSach;
        }
        public SVCNTT TimTheoMa(string mssv)
        {
            foreach (var item in danhSach)
            {
                if(item.MSSV.CompareTo(mssv)==0)
                {
                    return item;
                }
            }
            return null;
        }
        public void XoaTheoMa(string mssv)
        {
            SVCNTT sv = TimTheoMa(mssv);
            if (sv != null)
            {
                this.danhSach.Remove(sv);
            }
        }
        public void Don()
        {
            danhSach.Clear();
        }
        public void GhiRaFile(string tenFile)
        {
            using (StreamWriter sw = new StreamWriter(tenFile))
            {
                foreach (var item in danhSach)
                {
                    sw.WriteLine($"{item.MSSV}|{item.HoTen}|{item.GioiTinh}|{item.SDT}|{item.DiaChi}|{item.Email}|{item.Lop}|{item.Hinh}|{item.NgaySinh}");
                }
            }
        }
        public void DeepCopy(DanhSachSVCNTT other)
        {
            this.danhSach.Clear();
            foreach (var item in other.danhSach)
            {
                this.danhSach.Add(new SVCNTT(item.MSSV, item.HoTen, item.GioiTinh, item.SDT, item.DiaChi, item.Email, item.Lop, item.Hinh, item.NgaySinh));
            }
        }
    }
}
