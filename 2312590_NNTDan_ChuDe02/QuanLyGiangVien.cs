using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public enum KieuTim
    {
        TheoMa=0,
        TheoHoTen=1,
        TheoSDT=2,

    };
    
    public class QuanLyGiangVien
    {
        //delegate  vipro tốn của em 25p :))))))
        public delegate bool SoSanh(GiangVien a, string b);

        SoSanh soMa = (a, b) =>
        {
            return a.MaSo.Equals(b);
        };
        SoSanh soTen = (a, b) =>
        {
            return a.HoTen.Equals(b);
        };
        SoSanh soSDT = (a, b) =>
        {
            return a.SoDT.Equals(b);
        };

        public SoSanh GetSoSanh(KieuTim kieu)
        {
            switch (kieu)
            {
                case KieuTim.TheoMa:
                    return soMa;
                case KieuTim.TheoHoTen:
                    return soTen;
                case KieuTim.TheoSDT:
                    return soSDT;
                default:
                    return null;
            }
        }
        public GiangVien Tim(string findArg, SoSanh ss)
        {
            GiangVien gvResult = new GiangVien();
            foreach (GiangVien gv in dsGV)
            {
                if (ss(gv, findArg))
                {
                    gvResult = gv;
                    return gvResult;
                }
            }
            return null;
        }
        public GiangVien TimTheo(KieuTim tim,string findArg)
        {
            return Tim(findArg, GetSoSanh(tim));
        }
        //ket thuc delegate vipro tốn của em 25p :))))))


        List<GiangVien> dsGV;
        public QuanLyGiangVien()
        {
            dsGV = new List<GiangVien>();
        }
        public void SapXep(SoSanh ss)
        {

        }
        public bool Them(GiangVien gv)
        {
            foreach (GiangVien giangVien in dsGV)
            {
                if (gv.MaSo == giangVien.MaSo)
                {
                    return false;
                }
            }
            dsGV.Add(gv);
            return true;
        }
        
        //public GiangVien Xoa(object obj, SoSanh ss)
        //{
        //    //GiangVien gvResult = new GiangVien();
        //    //for (int i = dsGV.Count - 1; i >= 0; i--)
        //    //{
        //    //    if (ss(obj, dsGV[i]) == 0)
        //    //    {
        //    //        gvResult = dsGV[i];
        //    //        dsGV.RemoveAt(i);
        //    //        break;
        //    //    }
        //    //}
        //    //return gvResult;
        //}
    }
}
