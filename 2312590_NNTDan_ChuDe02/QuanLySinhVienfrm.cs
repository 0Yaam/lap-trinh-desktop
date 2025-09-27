using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyForm.QuanLySinhVien;

namespace MyForm
{
    public partial class QuanLySinhVienfrm : Form
    {
        QuanLySinhVien qlsv = new QuanLySinhVien();
        public SoSanhDelegate theoTen = (sv1, sv2) =>
        {
            return string.Compare(sv1.HoTen, sv2.HoTen);
        };
        public SoSanhDelegate theoMa = (sv1, sv2) =>
        {
            return string.Compare(sv1.MaSo, sv2.MaSo);
        };
        public SoSanhDelegate theoNgaySinh = (sv1, sv2) =>
        {
            return DateTime.Compare(sv1.NgaySinh, sv2.NgaySinh);
        };
        public QuanLySinhVienfrm()
        {
            InitializeComponent();
        }

        private void QuanLySinhVienfrm_Load(object sender, EventArgs e)
        {
            qlsv=new QuanLySinhVien();
            qlsv.DocTuFile("DanhSachSV.txt");
            LoadListView();
            UpdateStatus();
        }
        private void UpdateStatus()
        {
            lblStatus.Text = "So luong sinh vien: " + qlsv.dsSinhVien.Count.ToString();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count= this.lvSinhVien.SelectedItems.Count;
            if(count>0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }
        private void ThemSV(SinhVien sv)
        {
            if(sv==null)
            {
                return;
            }    
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Lop);
            string gt = "Nu";
            if (sv.GioiTinh)
            {
                gt = "Nam";
            }
            lvitem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.ChuyenNganh)
            {
                cn += s + ",";
            }
            cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
            UpdateStatus();
        }
        
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach(SinhVien sv in qlsv.dsSinhVien)
            {
                ThemSV(sv);
            }
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv=new SinhVien();
            bool gt = true;
            List<string> cn=new List<string>();
            sv.MaSo = this.mtxtMaSo.Text;
            sv.HoTen=this.txtHoTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.DiaChi = this.textDiaChi.Text;
            sv.Lop=this.cboLop.Text;
            sv.Hinh=this.txtHinh.Text;
            if(rdNu.Checked)
            {
                gt= false;
            }
            sv.GioiTinh = gt;
            if(this.clbChuyenNganh.CheckedItems.Count==0)
            {
                MessageBox.Show("Chua chon chuyen nganh", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            for(int i=0; i< this.clbChuyenNganh.Items.Count; i++)
            {
                if(clbChuyenNganh.GetItemChecked(i))
                {
                    cn.Add(clbChuyenNganh.Items[i].ToString()); 
                }

            }
            sv.ChuyenNganh = cn;
            return sv;
        }
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv=new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[2].Text);
            sv.DiaChi = lvitem.SubItems[3].Text;
            sv.Lop=lvitem.SubItems[4].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text=="Nam")
            {
                sv.GioiTinh=true;
            }
            List<string> cn= new List<string>();
            string[] s = lvitem.SubItems[6].Text.Split(',');
            foreach(string t in s)
            {
                cn.Add(t);
            }
            sv.ChuyenNganh=cn;
            sv.Hinh=lvitem.SubItems[7].Text;
            return sv;
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoTen.Text = sv.HoTen;
            this.dtpNgaySinh.Value= sv.NgaySinh;
            this.textDiaChi.Text = sv.DiaChi;
            this.cboLop.Text= sv.Lop;
            this.txtHinh.Text= sv.Hinh;
            this.pbHinh.ImageLocation=sv.Hinh;
            if (sv.GioiTinh)
            {
                this.rdNam.Checked = true;
            }
            else 
            {
                this.rdNu.Checked = true;
            }
            for (int i = 0;i<this.clbChuyenNganh.Items.Count;i++)
            {
                this.clbChuyenNganh.SetItemChecked(i, false);
            }
            foreach(string s in sv.ChuyenNganh)
            {
                for (int i = 0;i<this.clbChuyenNganh.Items.Count;i++)
                {
                    if (s.CompareTo(this.clbChuyenNganh.Items[i])==0)
                    {
                        this.clbChuyenNganh.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgaySinh.Value=DateTime.Now;
            this.textDiaChi.Text = "";
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count - 1;i++)
            {
                this.clbChuyenNganh.SetItemChecked(i,false);
            }
            UpdateStatus();
        }
        private void btnThoat_Click(object sender,EventArgs e)
        {
            Application.Exit();
        }
        private int SoSanhTheoMa(object sv1,object sv2)
        {
            SinhVien sv=sv2 as SinhVien;
            return sv.MaSo.CompareTo(sv1);
        }
        private int SoSanhTheoTen(object sv1,object sv2)
        {
            SinhVien sv= sv2 as SinhVien;
            return sv.HoTen.Trim().CompareTo(sv1);
        }
        private int SoSanhTheoNgaySinh(object sv1,object sv2)
        {
            SinhVien sv = sv2 as SinhVien;
            DateTime dateTime = DateTime.Parse(sv1.ToString());
            return DateTime.Compare(sv.NgaySinh.Date, dateTime.Date);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >=0; i--)
            {
                lvitem=this.lvSinhVien.Items[i];
                if(lvitem.Checked)
                {
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
                }
            }
            this.LoadListView();
            this.btnMacDinh.PerformClick();
            UpdateStatus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
            if (kqsua) 
            {
                this.LoadListView();
            }
            UpdateStatus();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile= new OpenFileDialog();
            openFile.Title = "Hay chon file";
            openFile.Filter = "Image File (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                string path = openFile.FileName;  
            }
        }

        private void lblMS_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void moFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile= new OpenFileDialog();
            openFile.Title = "Hay chon file";
            openFile.Filter = "Image File (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            openFile.ShowDialog();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemSV(GetSinhVien());
            UpdateStatus();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
            UpdateStatus();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontSetfrm fontSet = new FontSetfrm();
            if(fontSet.ShowDialog()==DialogResult.OK)
            {
                MessageBox.Show("ket qua la :" + fontSet.selectFont + "" + fontSet.selectSize + "" + fontSet.selectStyle);
            }
            lvSinhVien.Font = new Font(fontSet.selectFont, fontSet.selectSize, (FontStyle)Enum.Parse(typeof(FontStyle), fontSet.selectStyle));
        }

        private void mauChuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colorfrm colorfrm = new Colorfrm();
            if (colorfrm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Mau chu da chon: " + colorfrm.selectedColor);
                lvSinhVien.ForeColor = Color.FromName(colorfrm.selectedColor);
            }
            else
            {
                MessageBox.Show("Khong chon mau chu nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void sapXepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlsv.XapXepDanhSachTheo(theoTen);
            LoadListView();
            MessageBox.Show("danh sach da ay thanh cong");
        }

        private void timKiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemfrm timKiemfrm = new TimKiemfrm();
            if(timKiemfrm.ShowDialog()==DialogResult.OK)
            {
                
                QuanLySinhVien a = new QuanLySinhVien();
                a = qlsv.Tim(timKiemfrm.ma, SoSanhTheoMa);
                if (a != null)
                {
                    qlsv.dsSinhVien.Clear();
                    qlsv = a;
                    LoadListView();
                }
                else
                {
                    MessageBox.Show("Khong tim thay sinh vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void tuyChonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Optionfrm frm = new Optionfrm();
            QuanLySinhVien dskq = new QuanLySinhVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if(frm.how==Optionfrm.How.find)
                {
                    switch(frm.by)
                    {
                        case Optionfrm.By.id:
                            dskq = qlsv.Tim(frm.input, SoSanhTheoMa);
                            if (dskq.dsSinhVien != null)
                            {
                                qlsv.dsSinhVien.Clear();
                                qlsv = dskq;
                                LoadListView();
                            }
                            else
                            {
                                MessageBox.Show("Khong tim thay sinh vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case Optionfrm.By.name:
                            dskq = qlsv.Tim(frm.input, SoSanhTheoTen);
                            if (dskq != null)
                            {
                                qlsv.dsSinhVien.Clear();
                                qlsv = dskq;
                                LoadListView();
                            }
                            else
                            {
                                MessageBox.Show("Khong tim thay sinh vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case Optionfrm.By.bday:
                            //DateTime ngayGio = DateTime.Parse(frm.input);
                            dskq = qlsv.Tim(frm.input, SoSanhTheoNgaySinh);
                            if (dskq != null)
                            {
                                qlsv.dsSinhVien.Clear();
                                qlsv = dskq;
                                LoadListView();
                            }
                            else
                            {
                                MessageBox.Show("Khong tim thay sinh vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                    }
                    return;
                }
                else
                {
                    switch(frm.by)
                    {
                        case Optionfrm.By.id:
                            qlsv.XapXepDanhSachTheo(theoMa);
                            LoadListView();
                            break;
                        case Optionfrm.By.name:
                            qlsv.XapXepDanhSachTheo(theoTen);
                            LoadListView();
                            break;
                        case Optionfrm.By.bday:
                            qlsv.XapXepDanhSachTheo(theoNgaySinh);
                            LoadListView();
                            break;
                    }    
                }
            }
            else
            {
                MessageBox.Show("Khong chon truong hop nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}
