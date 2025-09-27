using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public class SVCNTT
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Lop { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Hinh { get; set; }
        public SVCNTT(string mssv, string hoTen, bool gioiTinh, string sdt, string diaChi, string email, string lop, string hinh,DateTime ngaySinh)
        {
            MSSV = mssv;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            SDT = sdt;
            DiaChi = diaChi;
            Email = email;
            Lop = lop;
            Hinh = hinh;
            NgaySinh = ngaySinh;
        }
        public SVCNTT()
        {

        }
    }
}
