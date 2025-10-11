using _2312590_NNTDan_De2.Object;
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
    public partial class frmTimKiem : Form
    {
        private readonly List<NhaCungCap> _source;
        private readonly Action<IEnumerable<NhaCungCap>> _onResult;
        public frmTimKiem(List<NhaCungCap> source, Action<IEnumerable<NhaCungCap>> onResult)
        {
            InitializeComponent();
            _source = source ?? new List<NhaCungCap>();
            _onResult = onResult ?? (_ => { });

            txtTimKiem.TextChanged += (_, __) => DoFilter();
            rdTen.CheckedChanged += (_, __) => DoFilter();
            rdSDT.CheckedChanged += (_, __) => DoFilter();
            DoFilter();

        }
        private void DoFilter()
        {
            IEnumerable<NhaCungCap> q = _source;
            

            string kw = (txtTimKiem.Text ?? "").Trim();
            if (!string.IsNullOrEmpty(kw))
            {
                string k = kw.ToLowerInvariant();
                if (rdTen != null && rdTen.Checked)
                    q = q.Where(sv => (sv.TenNCC ?? "").ToLowerInvariant().Contains(k));
                else if (rdSDT != null && rdSDT.Checked)
                    q = q.Where(sv => (sv.SDT ?? "").ToLowerInvariant().Contains(k));
            }

            _onResult(q.ToList());
        }

        private void rdTen_CheckedChanged(object sender, EventArgs e)
        {
            DoFilter();
        }

        private void rdSDT_CheckedChanged(object sender, EventArgs e)
        {
            DoFilter();
        }
    }
}
