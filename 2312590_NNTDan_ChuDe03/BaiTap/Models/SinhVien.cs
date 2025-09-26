using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTenLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Lop { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        public string GioiTinhText => GioiTinh ? "Nam" : "Nữ";
        public SinhVien()
        {
            
        }
        public SinhVien(string mssv, string hotenlot, string ten, DateTime ngaysinh, bool gioiTinh, string lop, string cmnd, string sdt, string diachi)
        {
            this.MSSV = mssv;
            this.HoTenLot = hotenlot;
            this.Ten = ten;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gioiTinh;
            this.Lop = lop;
            this.CMND = cmnd;
            this.SDT = sdt;
            this.DiaChi = diachi;
        }

    }
}
