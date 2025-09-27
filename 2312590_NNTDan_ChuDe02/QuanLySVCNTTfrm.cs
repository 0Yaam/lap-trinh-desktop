using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class QuanLySVCNTTfrm : Form
    {
        DanhSachSVCNTT dsSVCNTT = new DanhSachSVCNTT();
        DanhSachSVCNTT copy = new DanhSachSVCNTT();
        public QuanLySVCNTTfrm()
        {
            InitializeComponent();
            //dsSVCNTT.NhapCoDinh5SinhVien();
            dsSVCNTT.NhapTuFile("DSNV.txt");
            copy.DeepCopy(dsSVCNTT);
            HienThiDanhSach();
        }

        private void tbMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lblGT_Click(object sender, EventArgs e)
        {

        }

        private void lblSDT_Click(object sender, EventArgs e)
        {

        }

        private void lvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDanhSach.SelectedItems.Count>0)
            {
                ListViewItem selectedItem = lvDanhSach.SelectedItems[0];
                tbMS.Text = selectedItem.SubItems[0].Text;
                tbTen.Text = selectedItem.SubItems[1].Text;
                rdNam.Checked = selectedItem.SubItems[2].Text == "Nam";
                rdNu.Checked = selectedItem.SubItems[2].Text == "Nữ";
                cbLop.SelectedItem = selectedItem.SubItems[4].Text;
                foreach (string item in cbLop.Items)
                {
                    if (item == selectedItem.SubItems[4].Text)
                    {
                        cbLop.SelectedItem = item;
                        break;
                    }
                }
                mtbSDT.Text = selectedItem.SubItems[5].Text;
                tbEmail.Text = selectedItem.SubItems[6].Text;
                tbDiaChi.Text = selectedItem.SubItems[7].Text;
                tbDuongDan.Text = selectedItem.SubItems[8].Text;

            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pbHinh.Image = Image.FromFile(openFile.FileName);
                tbDuongDan.Text = openFile.FileName;
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            tbTen.Text = "";
            tbMS.Text = "";
            tbDiaChi.Text = "";
            tbEmail.Text = "";
            mtbSDT.Text = "";
            tbDuongDan.Text = "";
            dtpNSinh.Value = DateTime.Now;
            rdNam.Checked = true;
            cbLop.SelectedIndex = -1;


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QuanLySVCNTTfrm_Load(object sender, EventArgs e)
        {

        }
        public void HienThiDanhSach()
        {
            lvDanhSach.Items.Clear();
            List<SVCNTT> danhSach = dsSVCNTT.LayDanhSach();
            foreach (SVCNTT sv in danhSach)
            {
                ListViewItem item = new ListViewItem(sv.MSSV);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(sv.NgaySinh.ToShortDateString());
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SDT);
                item.SubItems.Add(sv.Email);
                item.SubItems.Add(sv.DiaChi);
                
               
                
                item.SubItems.Add(sv.Hinh);
                lvDanhSach.Items.Add(item);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SVCNTT tim= dsSVCNTT.TimTheoMa(tbMS.Text);
            if(tim!=null)
            {
                tim.HoTen = tbTen.Text;
                tim.GioiTinh = rdNam.Checked;
                tim.NgaySinh = dtpNSinh.Value;
                tim.Lop = cbLop.SelectedItem?.ToString();
                tim.SDT = mtbSDT.Text;
                tim.Email = tbEmail.Text;
                tim.DiaChi = tbDiaChi.Text;
                tim.Hinh = tbDuongDan.Text;
                
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã số này. Tiến hành thêm mới ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SVCNTT sv = new SVCNTT
                {
                    MSSV = tbMS.Text,
                    HoTen = tbTen.Text,
                    GioiTinh = rdNam.Checked,
                    NgaySinh = dtpNSinh.Value,
                    Lop = cbLop.SelectedItem?.ToString(),
                    Email = tbEmail.Text,
                    SDT = mtbSDT.Text,
                    DiaChi = tbDiaChi.Text,
                    Hinh = tbDuongDan.Text
                };
                dsSVCNTT.Them(sv);
            }
            HienThiDanhSach();
        }

        private void tsmiXoa_Opening(object sender, CancelEventArgs e)
        {

        }

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDanhSach.CheckedItems[0];
                DialogResult kq= MessageBox.Show("ban dinh xoa" + selectedItem.SubItems[1].Text, "Xoa sinh vien",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(kq==DialogResult.Yes)
                {
                    string mssv = selectedItem.SubItems[0].Text;
                    dsSVCNTT.XoaTheoMa(mssv);
                    HienThiDanhSach();
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void xoaSVDaChonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDanhSach.CheckedItems.Count > 0)
            {
                var checkedItem = lvDanhSach.CheckedItems;
                string s = "";
                foreach(ListViewItem item in checkedItem)
                {
                    s+=item.SubItems[1].Text + ", ";
                }
                DialogResult kq = MessageBox.Show("ban dinh xoa cac sinh vien" + s, "Xoa sinh vien", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(kq==DialogResult.Yes)
                {
                    foreach (ListViewItem item in checkedItem)
                    {
                        string mssv = item.SubItems[0].Text;
                        dsSVCNTT.XoaTheoMa(mssv);
                    }
                    HienThiDanhSach();
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void taiLaiDanhSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dsSVCNTT.Don();
            dsSVCNTT.NhapTuFile("DSNV.txt");
            HienThiDanhSach();
        }

        private void QuanLySVCNTTfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool coDoi=!dsSVCNTT.LayDanhSach().SequenceEqual(copy.LayDanhSach());
            if (coDoi)
            {
                DialogResult kq = MessageBox.Show("Xac nhan luu danh sach thay doi", "before you go", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (kq == DialogResult.OK)
                {
                    dsSVCNTT.GhiRaFile("DSNV.txt");
                }
            }
        }
    }
}
