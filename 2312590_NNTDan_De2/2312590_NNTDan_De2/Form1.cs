using _2312590_NNTDan_De2.Object;
using _2312590_NNTDan_De2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312590_NNTDan_De2
{
    public partial class Form1 : Form
    {
        private readonly List<NhaCungCap> dsncc = new List<NhaCungCap>();
        private readonly QLNCC ql = new QLNCC();
        private readonly string filename = "danhsach.txt";
        public Form1()
        {
            InitializeComponent();
            LoadListView();
        }


        private void LoadListView(IEnumerable<NhaCungCap> source = null)
        {
            lvDanhSach.Items.Clear();

            var list = source?.ToList() ?? ql.DocFile(filename);

            foreach (var sv in list)
                lvDanhSach.Items.Add(ToItem(sv));

        }

        private ListViewItem ToItem(NhaCungCap ncc)
        {
            var it = new ListViewItem(ncc.MaNCC);
            it.SubItems.Add(ncc.TenNCC);
            it.SubItems.Add(ncc.DiaChi);
            it.SubItems.Add(ncc.SDT);
            it.SubItems.Add(ncc.MoTa);
            it.Tag = ncc;
            return it;
        }

        private void Fill(NhaCungCap ncc)
        {
            txtMaNCC.Text = ncc.MaNCC;
            txtTenNCC.Text = ncc.TenNCC;
            txtDiaChi.Text = ncc.DiaChi;
            mtxtSDT.Text = ncc.SDT;
            txtMoTa.Text = ncc.MoTa;
        }

        private void lvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 0) return;
            var sv = (NhaCungCap)lvDanhSach.SelectedItems[0].Tag;
            Fill(sv);
        }


        private void ClearForm()
        {
            txtMaNCC.Clear();
           txtTenNCC.Clear();
            txtDiaChi.Clear();
            mtxtSDT.Clear();
            txtMoTa.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) ||
               string.IsNullOrWhiteSpace(txtTenNCC.Text) ||
               string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
               string.IsNullOrWhiteSpace(mtxtSDT.Text) ||
               string.IsNullOrWhiteSpace(txtMoTa.Text) || KiemTraSDT()) 
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            string manccMoi = txtMaNCC.Text.Trim();
            if (ql.KiemTraTrungNCCTrongFile(filename, manccMoi) ||
    lvDanhSach.Items.Cast<ListViewItem>().Any(i => i.Text.Equals(manccMoi, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("MS NCC đã tồn tại!", "Thông báo");
                return;
            }

            var ncc = new NhaCungCap
            {
                MaNCC = txtMaNCC.Text.Trim(),
                TenNCC = txtTenNCC.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SDT = mtxtSDT.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
            };

            dsncc.Add(ncc);
            ql.GhiFileTXT(filename, ncc);
            lvDanhSach.Items.Add(ToItem(ncc));
            ClearForm();



        }

        public bool KiemTraSDT()
        {
            if (mtxtSDT.Text.Length < 10 || mtxtSDT.Text.Length > 12)
            {
                return true;
            }
            return false;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            ql.XoaNCC(filename, listMSSV);

            for (int i = lvDanhSach.Items.Count - 1; i >= 0; i--)
                if (lvDanhSach.Items[i].Checked)
                    lvDanhSach.Items.RemoveAt(i);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var data = ql.DocFile(filename);
            var f = new frmTimKiem(
                source: data,
                onResult: (IEnumerable<NhaCungCap> kq) => LoadListView(kq)
            );
            f.Show(this);
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnXuatJson_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|JSON file (*.json)|*.json";
                sfd.Title = "Xuất danh sách sinh viên";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName;
                    //var storage = 2312590_NNTDan_De2.Services.DocGhiDS.cs;

                    // lấy danh sách hiện tại từ ListView
                    var list = new List<NhaCungCap>();
                    foreach (ListViewItem it in lvDanhSach.Items)
                    {
                        if (it.Tag is NhaCungCap sv)
                            list.Add(sv);
                    }

                    MessageBox.Show("Xuất file thành công!", "Thông báo");
                }
            }
        }
    }
}
