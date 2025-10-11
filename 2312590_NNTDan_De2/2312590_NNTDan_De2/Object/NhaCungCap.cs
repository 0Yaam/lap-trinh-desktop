using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312590_NNTDan_De2.Object
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MoTa { get; set; }

        public NhaCungCap()
        {
            
        }


        public NhaCungCap(string maNCC, string tenNCC, string diaChi,string sdt, string moTa)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            DiaChi = diaChi;
            SDT = sdt;
            MoTa = moTa;

        }


    }
}
