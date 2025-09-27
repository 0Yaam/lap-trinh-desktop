using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class frmGiangVien : Form
    {
        QuanLyGiangVien dsGV = new QuanLyGiangVien();
        
        public frmGiangVien()
        {
            InitializeComponent();
        }
        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            string lienHe = "https://cntt.dlu.edu.vn";
            this.linklbLienHe.Links.Add(0, lienHe.Length, lienHe);
            this.cboMaSo.SelectedItem = this.cboMaSo.Items[0];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Reset();
        }
        public void Reset()
        {
            this.cboMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.mtxtSoDT.Text = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < chklbNgoaiNgu.Items.Count; i++)
                chklbNgoaiNgu.SetItemChecked(i, false);
            foreach (object ob in this.lbHocPhanDay.Items)
                this.lbDanhSachHP.Items.Add(ob);
            this.lbHocPhanDay.Items.Clear();
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            frmTBGiangVien frm=new frmTBGiangVien();
            frm.SetText(GetGiangVien().ToString());
            frm.ShowDialog();
        }
        public GiangVien GetGiangVien()
        {
            string gt = "Nam";
            if(rdNu.Checked)
            {
                gt = "Nu";
            }
            GiangVien gv= new GiangVien();
            gv.MaSo=this.cboMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen=this.txtHoTen.Text;
            gv.NgaySinh=this.dtpNgaySinh.Value;
            gv.Mail=this.txtMail.Text;
            gv.SoDT=this.mtxtSoDT.Text;
            string ngoaiNgu = "";
            for(int i=0;i<chklbNgoaiNgu.Items.Count;i++)
            {
                if(chklbNgoaiNgu.GetItemChecked(i))
                {
                    ngoaiNgu += chklbNgoaiNgu.Items[i] + ";";
                }
            }
            gv.NgoaiNgu=ngoaiNgu.Split(';');
            DanhMucHocPhan dshp=new DanhMucHocPhan();
            foreach (object hp in lbHocPhanDay.Items)
                dshp.Them(new HocPhan(hp.ToString()));
            gv.dsHocPhan=dshp;
            return gv;
        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strlink=e.Link.LinkData.ToString();
            Process.Start(strlink);

        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i=this.lbDanhSachHP.SelectedItems.Count-1;
            while(i>=0)
            {
                this.lbHocPhanDay.Items.Add(lbDanhSachHP.SelectedItems[i]);
                this.lbDanhSachHP.Items.Remove(lbDanhSachHP.SelectedItems[i]);
                i--;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i=this.lbHocPhanDay.SelectedItems.Count-1;
            while (i >= 0) 
            {
                this.lbDanhSachHP.Items.Add(lbHocPhanDay.SelectedItems[i]);
                this.lbHocPhanDay.Items.Remove(lbHocPhanDay.SelectedItems[i]);
                i--;
            }
        }
        public GiangVien LayThongTin()
        {
            GiangVien gv=new GiangVien();
            gv.MaSo = this.cboMaSo.Text; 
            gv.HoTen=this.txtHoTen.Text;
            gv.Mail = this.txtMail.Text;
            gv.SoDT=this.mtxtSoDT.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value.Date;
            gv.GioiTinh = rdNam.Checked ? "Nam" : "Nu";
            gv.NgoaiNgu = new string[chklbNgoaiNgu.CheckedItems.Count];
            for(int i=0;i<chklbNgoaiNgu.CheckedItems.Count;i++)
            {
                gv.NgoaiNgu[i]=chklbNgoaiNgu.CheckedItems[i].ToString();
            }
            foreach(object ob in this.lbHocPhanDay.Items)
            {
                HocPhan hp = new HocPhan(ob.ToString());
                gv.dsHocPhan.Them(hp);
            }
            return gv;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            GiangVien gv = LayThongTin();
            
            if (dsGV.Them(gv))
            {
                MessageBox.Show("Them thanh cong giang vien: " + gv.HoTen, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Giang vien da ton tai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TimTTGV frmLayThongTinTim = new TimTTGV(this.dsGV);
            if(frmLayThongTinTim.ShowDialog()==DialogResult.OK)
            {
                GiangVien kq = frmLayThongTinTim.kqGV;
                if (kq == null)
                {
                    MessageBox.Show("Khong tim thay giang vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmTBGiangVien frmTBGV = new frmTBGiangVien();
                frmTBGV.SetText(kq.ToString());
                frmTBGV.ShowDialog();
            }
            
        }
    }

    public class HocPhan
    {
        public int ID { get; set; }
        public string TenHP {  get; set; }
        public int SoTC { get; set; }
        public HocPhan(string ten) {
            this.TenHP = ten;
        }
        public HocPhan(int id, string ten, int tc) { 
            this.ID = id;
            this.TenHP = ten;
            this.SoTC = tc;
        }
        public override string ToString() {
            return TenHP;
        }
    }

    public class DanhMucHocPhan
    {
        public List<HocPhan> ds;
        public DanhMucHocPhan()
        {
            ds = new List<HocPhan>();
        }
        public HocPhan this[int index]
        {
            get { return ds[index] as HocPhan; }
            set { ds[index] = value; }
        }
        public void Them(HocPhan hp)
        {
            ds.Add(hp);
        }
        public override string ToString() {
            string s = "Danh sach mon hoc: ";
            foreach(object mh in ds)
            {
                s += mh as HocPhan + ";";
            }
            return s;
        }
    }
    public class GiangVien
    {
        public string MaSo { get; set; }
        public string HoTen {  get; set; }
        public DateTime NgaySinh { get; set; }

        public DanhMucHocPhan dsHocPhan;
        public string GioiTinh;
        public string[] NgoaiNgu;
        public string SoDT;
        public string Mail;

        public GiangVien()
        {
            dsHocPhan=new DanhMucHocPhan();
            NgoaiNgu = new string[20];
        }
        public GiangVien(string maso, string sdt, string mail, string hoten, DateTime ngaySinh, DanhMucHocPhan ds, string gt, string[] nn)
        {
            this.MaSo = maso;
            this.HoTen = hoten;
            this.NgaySinh= ngaySinh;
            this.dsHocPhan = ds;
            this.NgoaiNgu= nn;
            this.SoDT = sdt;
            this.Mail = mail;
            this.GioiTinh = gt;

        }
        public override string ToString()
        {
            string s = "Ma so: " + MaSo + "\n"
                + "Ho ten: " + HoTen + "\n"
                + "Ngay Sinh: " + NgaySinh + "\n"
                + "Gioi Tinh: " + GioiTinh + "\n"
                + "So DT: " + SoDT + "\n"
                + "Mail: " + Mail + "\n";
            string sngoaingu = "Ngoai ngu";
            foreach (string t in NgoaiNgu) {
                sngoaingu += t + ";";
            }
            string monDay = "Danh sach mon day: ";
            foreach(HocPhan hp in dsHocPhan.ds)
            {
                monDay += hp + ";";
            }
            s += "\n" + sngoaingu + "\n" + monDay;
            return s;
        }

    }
    
}
