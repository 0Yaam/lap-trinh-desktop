using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class frmMain : Form
    {
        private readonly List<SinhVien> dssv = new List<SinhVien>();
        private readonly QLSinhVien ql = new QLSinhVien();
        private readonly string filename = "danhsach.txt";

        public frmMain()
        {
            InitializeComponent();
            LoadListView();

            clbMonHoc.MultiColumn = true;
            clbMonHoc.ColumnWidth = 200;
            clbMonHoc.HorizontalScrollbar = true;

            lvDanhSach.SelectedIndexChanged += LvDanhSach_SelectedIndexChanged;

            if (cbbLocTheoLop != null)
                cbbLocTheoLop.SelectedIndexChanged += (s, e) => LocTheoLop();
        }

        // Nạp dữ liệu vào ListView
        private void LoadListView(IEnumerable<SinhVien> source = null)
        {
            var list = source?.ToList() ?? ql.DocFile(filename);

            foreach (var sv in list)
                lvDanhSach.Items.Add(ToItem(sv));
        }

        // Convert SinhVien -> ListViewItem
        private ListViewItem ToItem(SinhVien sv)
        {
            var it = new ListViewItem(sv.MSSV);
            it.SubItems.Add(sv.HoTenLot);
            it.SubItems.Add(sv.Ten);
            it.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            it.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
            it.SubItems.Add(sv.Lop);
            it.SubItems.Add(sv.CMND);
            it.SubItems.Add(sv.SDT);
            it.SubItems.Add(sv.DiaChi);
            it.Tag = sv;
            return it;
        }

        private void LvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 0) return;
            var sv = (SinhVien)lvDanhSach.SelectedItems[0].Tag;
            Fill(sv);
            txtMSSV.ReadOnly = true;
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

        private void ClearForm()
        {
            txtMSSV.Clear();
            txtHoVaTenLot.Clear();
            txtTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = true;
            rdNu.Checked = false;
            cbbLop.SelectedIndex = -1;
            mtxtCMND.Clear();
            mtxtSDT.Clear();
            txtDiaChi.Clear();

            for (int i = 0; i < clbMonHoc.Items.Count; i++)
                clbMonHoc.SetItemChecked(i, false);
        }

        // Nút thêm mới
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoVaTenLot.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(cbbLop.Text) ||
                string.IsNullOrWhiteSpace(mtxtCMND.Text) ||
                string.IsNullOrWhiteSpace(mtxtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            string mssvMoi = txtMSSV.Text.Trim();
            if (ql.KiemTraTrungMSSVTrongFile(filename, mssvMoi) ||
                lvDanhSach.Items.Cast<ListViewItem>().Any(i => i.Text.Equals(mssvMoi, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("MSSV đã tồn tại!", "Thông báo");
                return;
            }

            var sv = new SinhVien
            {
                MSSV = txtMSSV.Text.Trim(),
                HoTenLot = txtHoVaTenLot.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = rdNam.Checked,
                Lop = cbbLop.Text.Trim(),
                CMND = mtxtCMND.Text.Trim(),
                SDT = mtxtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            dssv.Add(sv);
            ql.GhiFile(filename, sv);

            lvDanhSach.Items.Add(ToItem(sv));

            ClearForm();
            txtMSSV.ReadOnly = false;
        }

        // Nút cập nhật
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text)) return;

            var sv = new SinhVien
            {
                MSSV = txtMSSV.Text.Trim(),
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
            if (!ok)
            {
                MessageBox.Show("Không tìm thấy MSSV để cập nhật!", "Thông báo");
                return;
            }

            if (lvDanhSach.SelectedItems.Count > 0)
            {
                var idx = lvDanhSach.SelectedItems[0].Index;
                lvDanhSach.Items[idx] = ToItem(sv);
            }
            else
            {
                LoadListView();
            }

            MessageBox.Show("Đã cập nhật!", "Thông báo");
        }

        // Lọc theo lớp
        private void LocTheoLop()
        {
            string lop = cbbLocTheoLop.Text;
            if (string.IsNullOrEmpty(lop) || lop.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                LoadListView();
                return;
            }

            var list = ql.DocFile(filename).Where(sv => sv.Lop.Equals(lop, StringComparison.OrdinalIgnoreCase));
            LoadListView(list);
        }

        // Context menu: Cập nhật
        private void cmsCapNhat_Click(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 0) return;
            var sv = (SinhVien)lvDanhSach.SelectedItems[0].Tag;
            Fill(sv);
            txtMSSV.ReadOnly = true;
        }

        // Context menu: Xoá
        private void cmsXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 0) return;

            var listMSSV = lvDanhSach.SelectedItems
                .Cast<ListViewItem>()
                .Select(it => it.Text)
                .ToList();

            if (listMSSV.Count == 1)
                ql.XoaSV(filename, listMSSV[0]);
            else
                ql.XoaSV(filename, listMSSV);

            LoadListView();
            MessageBox.Show("Đã xoá!", "Thông báo");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lvDanhSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvDanhSach.GetItemAt(e.X, e.Y) == null)
            {
                ClearForm();
                lvDanhSach.SelectedItems.Clear();
                txtMSSV.ReadOnly = false;
            }
        }

        private void cbbLocTheoLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
