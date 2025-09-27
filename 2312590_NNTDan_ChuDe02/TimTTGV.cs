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
    public partial class TimTTGV : Form
    {
        public TimTTGV()
        {
            InitializeComponent();
        }

        private void gbTim_Enter(object sender, EventArgs e)
        {

        }
        //tra ve ket qua voi thuoc tinh
        public GiangVien kqGV { get; private set; }

        //nhận dsgv từ frmGiangVien
        private QuanLyGiangVien dsGV;
        public TimTTGV(QuanLyGiangVien ds)
        {
            InitializeComponent();
            this.dsGV = ds;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            KieuTim tim;
            if(rdMa.Checked)
            {
                tim = KieuTim.TheoMa;
            }
            else if(rdName.Checked)
            {
                tim = KieuTim.TheoHoTen;
            }
            else if(rdPN.Checked)
            {
                tim = KieuTim.TheoSDT;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                
            }
            string findArg = tbFind.Text.Trim();
            kqGV = dsGV.TimTheo(tim, findArg);

            this.DialogResult = DialogResult.OK;
        }

        private void TimTTGV_Load(object sender, EventArgs e)
        {

        }
    }
}
