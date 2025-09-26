using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class frmMain : Form
    {
        private List<SinhVien> dssv = new List<SinhVien>();
        private QLSinhVien ql = new QLSinhVien();
        string filename = "danhsach.txt";
        public frmMain()
        {
            InitializeComponent();
            LoaddgvDanhSach();



            clbMonHoc.MultiColumn = true;
            clbMonHoc.ColumnWidth = 92;
            clbMonHoc.HorizontalScrollbar = true;
            dgvDanhSach.AutoGenerateColumns = true;
        }
        private void LoaddgvDanhSach()
        {
            
            List<SinhVien> list = ql.DocFile(filename);
            dgvDanhSach.DataSource = list;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtMSSV.Text) || string.IsNullOrWhiteSpace(txtHoVaTenLot.Text) || string.IsNullOrWhiteSpace(txtTen.Text) || string.IsNullOrWhiteSpace(cbbLop.Text) || string.IsNullOrWhiteSpace(mtxtCMND.Text) || string.IsNullOrWhiteSpace(mtxtSDT.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            string mssvMoi = txtMSSV.Text.Trim();
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.IsNewRow) continue; 
                if (row.Cells["MSSV"].Value?.ToString() == mssvMoi)
                {
                    MessageBox.Show("MSSV đã tồn tại trong danh sách!", "Thông báo");
                    return;
                }
            }

            var sv = new SinhVien
            {
                MSSV = txtMSSV.Text,
                HoTenLot = txtHoVaTenLot.Text,
                Ten = txtTen.Text,
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = rdNam.Checked,
                Lop = cbbLop.Text,
                CMND = mtxtCMND.Text,
                SDT = mtxtSDT.Text,
                DiaChi = txtDiaChi.Text
            };
            dssv.Add(sv);
            ql.GhiFile(filename, sv);
            ClearForm();
            LoaddgvDanhSach();

        }

        private void ClearForm()
        {
            txtMSSV.Clear();
            txtHoVaTenLot.Clear();
            txtTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = true;
            cbbLop.SelectedIndex = -1;
            mtxtCMND.Clear();
            mtxtSDT.Clear();
            txtDiaChi.Clear();
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                clbMonHoc.SetItemChecked(i, false);
            }
        }

        private void DgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            txtMSSV.ReadOnly = true;
            if (dgvDanhSach.CurrentRow?.DataBoundItem is SinhVien sv)
            {
                Fill(sv);
            }
        }

        private void Fill(SinhVien sv)
        {
            txtMSSV.Text = sv.MSSV;
            txtHoVaTenLot.Text = sv.HoTenLot;
            txtTen.Text = sv.Ten;
            dtpNgaySinh.Value = sv.NgaySinh;        
            rdNam.Checked = sv.GioiTinh;              
            rdNu.Checked = !sv.GioiTinh;            
            cbbLop.Text = sv.Lop;
            mtxtCMND.Text = sv.CMND;
            mtxtSDT.Text = sv.SDT;
            txtDiaChi.Text = sv.DiaChi;
        }

        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmsCapNhat_Click(object sender, EventArgs e)
        {
            Fill((SinhVien)dgvDanhSach.CurrentRow.DataBoundItem);
        }


        private void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                ClearForm();
                dgvDanhSach.ClearSelection();
                txtMSSV.ReadOnly = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var sv = new SinhVien
            {
                MSSV = txtMSSV.Text.Trim(),           // KHÓA, thường để ReadOnly khi edit
                HoTenLot = txtHoVaTenLot.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = rdNam.Checked,
                Lop = cbbLop.Text.Trim(),
                CMND = mtxtCMND.Text.Trim(),
                SDT = mtxtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            bool ok = ql.CapNhatSV(filename, sv);
            if (!ok) MessageBox.Show("Error", "Thông báo", MessageBoxButtons.OK);

            LoaddgvDanhSach();
        }

        private void cbbLocTheoLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loc();
        }

        private void Loc()
        {
            string lop = cbbLocTheoLop.Text;
            if(string.IsNullOrEmpty(lop)||lop.Equals("None"))
            {
                LoaddgvDanhSach();
                return;
            }
            var list = ql.DocFile(filename);
            var filter = list.Where(sv => sv.Lop == lop).ToList();
            dgvDanhSach.DataSource = filter;
        }

        private void cmsXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0) return;

            var listMSSV = dgvDanhSach.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => ((SinhVien)r.DataBoundItem).MSSV)
                .ToList();

            ql.XoaSV(filename, listMSSV);
            LoaddgvDanhSach();

            MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo",
                MessageBoxButtons.OK);
        }

        private void dgvDanhSach_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvDanhSach.ClearSelection(); // clear chọn cũ
                dgvDanhSach.Rows[e.RowIndex].Selected = true; // chọn dòng hiện tại
                dgvDanhSach.CurrentCell = dgvDanhSach.Rows[e.RowIndex].Cells[0]; // focus
            }
        }


    }
}
