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
    public partial class Optionfrm : Form
    {
        public Optionfrm()
        {
            InitializeComponent();
        }

        private void tbThongTin_TextChanged(object sender, EventArgs e)
        {

        }

        private void Optionfrm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public enum How
        {
            find,
            sort
        }
        public enum By
        {
            id,
            name,
            bday
        }
        public How how { get; set; }
        public string input { get; set; }
        public By by { get; set; }
        public By GetRadio()
        {
            if(rdMa.Checked)
            {
                return By.id;
            }
            else if(rdName.Checked)
            {
                return By.name;
            }
            else
            {
                return By.bday;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            how = How.find;
            by = GetRadio();
            input =tbThongTin.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            how = How.sort;
            by = GetRadio();
            this.DialogResult = DialogResult.OK;    
        }
    }
}
