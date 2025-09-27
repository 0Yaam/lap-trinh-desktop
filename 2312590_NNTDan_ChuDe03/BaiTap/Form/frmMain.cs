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
        private int _rightClickIndex = -1;
        private string monHocFile = "monhoc.txt";
        private readonly string dkFile = "dangky.txt";

        public frmMain()
        {
            InitializeComponent();
            LoadListView();


            lvDanhSach.SelectedIndexChanged += LvDanhSach_SelectedIndexChanged;

            if (cbbLocTheoLop != null)
                cbbLocTheoLop.SelectedIndexChanged += (s, e) => LocTheoLop();

            clbMonHoc.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    int idx = clbMonHoc.IndexFromPoint(e.Location);
                    _rightClickIndex = idx;
                    if (idx >= 0) clbMonHoc.SelectedIndex = idx; // highlight item
                    else clbMonHoc.ClearSelected();
                }
            };
        }

        // nap du lieu len ListView
        private void LoadListView(IEnumerable<SinhVien> source = null)
        {
            lvDanhSach.Items.Clear();        

            var list = source?.ToList() ?? ql.DocFile(filename);

            foreach (var sv in list)
                lvDanhSach.Items.Add(ToItem(sv));

        }


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
            var mons = LoadDangKyForStudent(sv.MSSV);
            SetCheckedMon(mons);

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
            var mons = GetCheckedMon();
            SaveDangKyForStudent(sv.MSSV, mons);

            dssv.Add(sv);
            ql.GhiFile(filename, sv);

            lvDanhSach.Items.Add(ToItem(sv));

            ClearForm();
            txtMSSV.ReadOnly = false;
        }

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

            var mons = GetCheckedMon();
            SaveDangKyForStudent(sv.MSSV, mons);

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

        private void cmsXoa_Click(object sender, EventArgs e)
        {
            var listMSSV = lvDanhSach.Items
       .Cast<ListViewItem>()
       .Where(it => it.Checked)
       .Select(it => it.Text)    
       .ToList();

            if (listMSSV.Count == 0)
            {
                MessageBox.Show("Chưa tick dòng nào để xoá.", "Thông báo");
                return;
            }

            if (MessageBox.Show($"Xóa {listMSSV.Count} sinh viên đã tick?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            // xoa trong file
            ql.XoaSV(filename, listMSSV);

            RemoveDangKyForStudents(listMSSV);

            //xoa tren ui
            for (int i = lvDanhSach.Items.Count - 1; i >= 0; i--)
                if (lvDanhSach.Items[i].Checked)
                    lvDanhSach.Items.RemoveAt(i);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var data = ql.DocFile(filename);
            var f = new frmTimKiem(
                source: data,
                onResult: (IEnumerable<SinhVien> kq) => LoadListView(kq)
            );
            f.Show(this); 
        }

        private void txtMSSV_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        private void SaveMonHoc()
        {
            var dsMon = clbMonHoc.Items.Cast<object>()
                                       .Select(x => x.ToString())
                                       .ToList();
            System.IO.File.WriteAllLines(monHocFile, dsMon);
        }

        private void mnuXoaMon_Click(object sender, EventArgs e)
        {
            if (_rightClickIndex >= 0 && _rightClickIndex < clbMonHoc.Items.Count)
            {
                var ten = clbMonHoc.Items[_rightClickIndex].ToString();
                if (MessageBox.Show($"Xóa môn \"{ten}\"?", "Xác nhận",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clbMonHoc.Items.RemoveAt(_rightClickIndex);
                    SaveMonHoc(); 
                }
                _rightClickIndex = -1;
                return;
            }

            // Xóa tất cả item được tick
            for (int i = clbMonHoc.Items.Count - 1; i >= 0; i--)
                if (clbMonHoc.GetItemChecked(i))
                    clbMonHoc.Items.RemoveAt(i);

            SaveMonHoc();   
        }

        private List<string> GetCheckedMon()
        {
            return clbMonHoc.CheckedItems
                            .Cast<object>()
                            .Select(x => x.ToString().Trim())
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .Distinct(StringComparer.OrdinalIgnoreCase)
                            .ToList();
        }

        private void SetCheckedMon(IEnumerable<string> mons)
        {
            // bỏ tick tất cả
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
                clbMonHoc.SetItemChecked(i, false);

            if (mons == null) return;

            foreach (var m in mons)
            {
                int idx = -1;
                for (int i = 0; i < clbMonHoc.Items.Count; i++)
                {
                    if (string.Equals(clbMonHoc.Items[i].ToString().Trim(), m, StringComparison.OrdinalIgnoreCase))
                    {
                        idx = i; break;
                    }
                }
                if (idx < 0)
                {
                    idx = clbMonHoc.Items.Add(m);
                }
                clbMonHoc.SetItemChecked(idx, true);
            }
        }

        private Dictionary<string, List<string>> LoadAllDangKy()
        {
            var map = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            if (!System.IO.File.Exists(dkFile)) return map;

            foreach (var line in System.IO.File.ReadAllLines(dkFile))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');
                if (parts.Length < 2) continue;

                var mssv = parts[0].Trim();
                var mons = (parts[1] ?? "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(s => s.Trim())
                                            .Where(s => s.Length > 0)
                                            .Distinct(StringComparer.OrdinalIgnoreCase)
                                            .ToList();
                map[mssv] = mons;
            }
            return map;
        }

        private void SaveDangKyForStudent(string mssv, List<string> mons)
        {
            var map = LoadAllDangKy();
            map[mssv] = mons ?? new List<string>();
            var lines = map.Select(kv => $"{kv.Key}|{string.Join(";", kv.Value)}").ToArray();
            System.IO.File.WriteAllLines(dkFile, lines);
        }
        private List<string> LoadDangKyForStudent(string mssv)
        {
            var map = LoadAllDangKy();
            return map.TryGetValue(mssv, out var mons) ? mons : new List<string>();
        }


        private void RemoveDangKyForStudents(List<string> listMssv)
        {
            var map = LoadAllDangKy(); 
            foreach (var id in listMssv)
                map.Remove(id);
            var lines = map.Select(kv => $"{kv.Key}|{string.Join(";", kv.Value)}").ToArray();
            System.IO.File.WriteAllLines(dkFile, lines);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            // chọn nơi lưu
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|JSON file (*.json)|*.json";
                sfd.Title = "Xuất danh sách sinh viên";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName;
                    var storage = BaiTap.Services.DocGhiDS.ChonTheoFile(path);

                    // lấy danh sách hiện tại từ ListView
                    var list = new List<SinhVien>();
                    foreach (ListViewItem it in lvDanhSach.Items)
                    {
                        if (it.Tag is SinhVien sv)
                            list.Add(sv);
                    }

                    storage.Ghi(path, list);

                    MessageBox.Show("Xuất file thành công!", "Thông báo");
                }
            }
        }

        private void btnNhapFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|JSON file (*.json)|*.json";
                ofd.Title = "Nhập danh sách sinh viên";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;
                    var storage = BaiTap.Services.DocGhiDS.ChonTheoFile(path);

                    var list = storage.Doc(path);

                    if (list.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu trong file.", "Thông báo");
                        return;
                    }

                    // Cập nhật danh sách trong bộ nhớ
                    dssv.Clear();
                    dssv.AddRange(list);

                    // Ghi lại vào file chính (danhsach.txt) để đồng bộ
                    var txtStorage = new BaiTap.Services.DocGhiTxt();
                    txtStorage.Ghi(filename, dssv);

                    // nạp vào ListView
                    lvDanhSach.Items.Clear();
                    foreach (var sv in dssv)
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
                        lvDanhSach.Items.Add(it);
                    }

                    MessageBox.Show("Nhập dữ liệu thành công và đã lưu!", "Thông báo");
                }
            }
        }

        private void mnuThemMon_Click(object sender, EventArgs e)
        {
            var f = new frmThemMon(clbMonHoc, monHocFile);
            f.Show(this);
        }
    }
}
