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
    public partial class FontSetfrm : Form
    {
        public FontSetfrm()
        {
            InitializeComponent();
        }

        private void lblFont_Click(object sender, EventArgs e)
        {

        }
        public string selectFont { get; set; }
        public int selectSize { get; set; }
        public string selectStyle { get; set; }
        private void btnOk_Click(object sender, EventArgs e)
        {
            selectFont = this.cbFont.Text;
            selectSize = (int)this.nSize.Value;
            selectStyle = this.cbType.SelectedItem.ToString();
            MessageBox.Show(Text = "Font: " + selectFont + "\nSize: " + selectSize + "\nStyle: " + selectStyle, "Selected Font", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void FontSetfrm_Load(object sender, EventArgs e)
        {
            cbFont.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
        }
    }
}
