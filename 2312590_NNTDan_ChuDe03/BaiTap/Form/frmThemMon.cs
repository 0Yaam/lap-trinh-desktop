using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class frmThemMon : Form
    {
        private CheckedListBox _clb;
        private string _monHocFile;

        public frmThemMon(CheckedListBox clb, string monHocFile)
        {
            InitializeComponent();
            _clb = clb;
            _monHocFile = monHocFile;

            this.AcceptButton = btnThem;   
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var ten = (txtTenMon.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập tên môn.", "Thông báo");
                txtTenMon.Focus();
                return;
            }

            bool exists = _clb.Items.Cast<object>()
                .Any(x => string.Equals(x.ToString(), ten, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                MessageBox.Show("Môn đã tồn tại!", "Thông báo");
                txtTenMon.Clear();
                txtTenMon.Focus();
                return;
            }

            int idx = _clb.Items.Add(ten);

            // lưu lại file
            File.WriteAllLines(_monHocFile, _clb.Items.Cast<object>().Select(x => x.ToString()));

            txtTenMon.Clear();
            txtTenMon.Focus();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
