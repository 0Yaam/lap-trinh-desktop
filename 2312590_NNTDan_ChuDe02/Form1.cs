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
    public partial class frmTrungTam : Form
    {
        public frmTrungTam()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTrungTam_Load(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            this.cboMaHV.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgayDangKy.Value = DateTime.Now;
            this.rdNam.Checked = true;
            this.chkTiengAnhA.Checked = false;
            this.chkTiengAnhB.Checked = false;
            this.chkTinHocA.Checked = false;
            this.chkTinHocB.Checked = false;
            this.txtTongTien.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void btnTinhTien_Click_Click(object sender, EventArgs e)
        {
            int s = 0;
            if(chkTinHocA.Checked)
            {
                s += int.Parse(lblTienTHA.Text.Split('.')[0]);
            }
            if(chkTinHocB.Checked)
            {
                s += int.Parse(lblTienTHB.Text.Split('.')[0]);
            }
            if(chkTiengAnhA.Checked)
            {
                s += int.Parse(lblTienTAA.Text.Split('.')[0]);
            }
            if(chkTiengAnhB.Checked)
            {
                s += int.Parse(lblTienTHB.Text.Split('.')[0]);
            }
            this.txtTongTien.Text = s + ".000 đồng";
        }
    }
}
