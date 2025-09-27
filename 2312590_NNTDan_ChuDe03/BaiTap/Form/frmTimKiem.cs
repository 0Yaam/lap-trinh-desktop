// frmTimKiem.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class frmTimKiem : Form
    {
        private readonly List<SinhVien> _source;
        private readonly Action<IEnumerable<SinhVien>> _onResult;

        public frmTimKiem(List<SinhVien> source, Action<IEnumerable<SinhVien>> onResult)
        {
            InitializeComponent();
            _source = source ?? new List<SinhVien>();
            _onResult = onResult ?? (_ => { });

            LoadLopToCombo();

            txtTimKiem.TextChanged += (_, __) => DoFilter();
            rdMSSV.CheckedChanged += (_, __) => DoFilter();
            rdHoTenLot.CheckedChanged += (_, __) => DoFilter();
            rdTen.CheckedChanged += (_, __) => DoFilter();
            rdCMND.CheckedChanged += (_, __) => DoFilter();
            rdSDT.CheckedChanged += (_, __) => DoFilter();
            rdDiaChi.CheckedChanged += (_, __) => DoFilter();

            rdNam.CheckedChanged += (_, __) => DoFilter();
            rdNu.CheckedChanged += (_, __) => DoFilter();

            cbbLocTheoLop.SelectedIndexChanged += (_, __) => DoFilter();

            DoFilter();
        }

        private void LoadLopToCombo()
        {
            var allLop = _source
                .Select(s => s.Lop?.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(s => s)
                .ToList();

            cbbLocTheoLop.Items.Clear();
            cbbLocTheoLop.Items.Add("Tất cả"); 
            cbbLocTheoLop.Items.AddRange(allLop.Cast<object>().ToArray());
            cbbLocTheoLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLocTheoLop.SelectedIndex = 0;
        }

        private void DoFilter()
        {
            IEnumerable<SinhVien> q = _source;
            var lopSelected = cbbLocTheoLop.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(lopSelected) &&
                !string.Equals(lopSelected, "Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                q = q.Where(sv => sv.Lop != null &&
                                  sv.Lop.Equals(lopSelected, StringComparison.OrdinalIgnoreCase));
            }

            bool filterNam = rdNam != null && rdNam.Checked;
            bool filterNu = rdNu != null && rdNu.Checked;

            if (filterNam ^ filterNu) // chỉ một trong hai true
            {
                bool wantNam = filterNam;
                q = q.Where(sv => sv.GioiTinh == wantNam);
            }

            // 3) Lọc theo TRƯỜNG được chọn + từ khoá
            string kw = (txtTimKiem.Text ?? "").Trim();
            if (!string.IsNullOrEmpty(kw))
            {
                string k = kw.ToLowerInvariant();
                if (rdMSSV != null && rdMSSV.Checked)
                    q = q.Where(sv => (sv.MSSV ?? "").ToLowerInvariant().Contains(k));
                else if (rdHoTenLot != null && rdHoTenLot.Checked)
                    q = q.Where(sv => (sv.HoTenLot ?? "").ToLowerInvariant().Contains(k));
                else if (rdTen != null && rdTen.Checked)
                    q = q.Where(sv => (sv.Ten ?? "").ToLowerInvariant().Contains(k));
                else if (rdCMND != null && rdCMND.Checked)
                    q = q.Where(sv => (sv.CMND ?? "").ToLowerInvariant().Contains(k));
                else if (rdSDT != null && rdSDT.Checked)
                    q = q.Where(sv => (sv.SDT ?? "").ToLowerInvariant().Contains(k));
                else if (rdDiaChi != null && rdDiaChi.Checked)
                    q = q.Where(sv => (sv.DiaChi ?? "").ToLowerInvariant().Contains(k));
                // nếu chưa chọn radio nào (hiếm) -> không lọc theo trường
            }

            _onResult(q.ToList());
        }

        private void rdCMND_CheckedChanged(object sender, EventArgs e) => DoFilter();
        private void cbbLocTheoLop_SelectedIndexChanged(object sender, EventArgs e) => DoFilter();
        private void rdNu_CheckedChanged(object sender, EventArgs e) => DoFilter();
        private void rdNam_CheckedChanged(object sender, EventArgs e) => DoFilter();
        private void rdMSSV_CheckedChanged(object sender, EventArgs e) => DoFilter();
        private void rdTen_CheckedChanged(object sender, EventArgs e) => DoFilter();
        private void rdHoTenLot_CheckedChanged(object sender, EventArgs e) => DoFilter();
        private void rdDiaChi_CheckedChanged(object sender, EventArgs e) => DoFilter();
        private void txtTimKiem_TextChanged(object sender, EventArgs e) => DoFilter();

        private void btnReset_Click(object sender, EventArgs e)
        {
            rdNam.Checked = false;
            rdNu.Checked = false;
        }
    }
}
