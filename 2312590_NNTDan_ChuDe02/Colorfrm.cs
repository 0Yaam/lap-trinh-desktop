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
    public partial class Colorfrm : Form
    {
        public Colorfrm()
        {
            InitializeComponent();
        }

        private void Colorfrm_Load(object sender, EventArgs e)
        {
            cbColor.SelectedIndex = 0;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            Application.Exit();
        }
        public string selectedColor { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
            this.selectedColor = cbColor.SelectedItem.ToString();
        }
    }
}
