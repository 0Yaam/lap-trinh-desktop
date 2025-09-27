namespace MyForm
{
    partial class TimTTGV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTim = new System.Windows.Forms.GroupBox();
            this.rdPN = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.rdMa = new System.Windows.Forms.RadioButton();
            this.lblMa = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbTim.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTim
            // 
            this.gbTim.Controls.Add(this.rdPN);
            this.gbTim.Controls.Add(this.rdName);
            this.gbTim.Controls.Add(this.rdMa);
            this.gbTim.Location = new System.Drawing.Point(12, 12);
            this.gbTim.Name = "gbTim";
            this.gbTim.Size = new System.Drawing.Size(303, 61);
            this.gbTim.TabIndex = 0;
            this.gbTim.TabStop = false;
            this.gbTim.Text = "Tim theo";
            this.gbTim.Enter += new System.EventHandler(this.gbTim_Enter);
            // 
            // rdPN
            // 
            this.rdPN.AutoSize = true;
            this.rdPN.Location = new System.Drawing.Point(204, 38);
            this.rdPN.Name = "rdPN";
            this.rdPN.Size = new System.Drawing.Size(93, 17);
            this.rdPN.TabIndex = 2;
            this.rdPN.TabStop = true;
            this.rdPN.Text = "So Dien Thoai";
            this.rdPN.UseVisualStyleBackColor = true;
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Location = new System.Drawing.Point(109, 38);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(61, 17);
            this.rdName.TabIndex = 1;
            this.rdName.TabStop = true;
            this.rdName.Text = "Ho Ten";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // rdMa
            // 
            this.rdMa.AutoSize = true;
            this.rdMa.Location = new System.Drawing.Point(7, 38);
            this.rdMa.Name = "rdMa";
            this.rdMa.Size = new System.Drawing.Size(58, 17);
            this.rdMa.TabIndex = 0;
            this.rdMa.TabStop = true;
            this.rdMa.Text = "Ma GV";
            this.rdMa.UseVisualStyleBackColor = true;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(12, 94);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(40, 13);
            this.lblMa.TabIndex = 1;
            this.lblMa.Text = "Ma GV";
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(82, 91);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(164, 20);
            this.tbFind.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(252, 89);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(57, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Tim";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // TimTTGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 131);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.gbTim);
            this.Name = "TimTTGV";
            this.Text = "TimTTGV";
            this.Load += new System.EventHandler(this.TimTTGV_Load);
            this.gbTim.ResumeLayout(false);
            this.gbTim.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTim;
        private System.Windows.Forms.RadioButton rdPN;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.RadioButton rdMa;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnFind;
    }
}