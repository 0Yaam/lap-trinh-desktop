namespace MyForm
{
    partial class Optionfrm
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
            this.gpHow = new System.Windows.Forms.GroupBox();
            this.rdMa = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.rdBD = new System.Windows.Forms.RadioButton();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbThongTin = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.gpHow.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpHow
            // 
            this.gpHow.Controls.Add(this.rdBD);
            this.gpHow.Controls.Add(this.rdName);
            this.gpHow.Controls.Add(this.rdMa);
            this.gpHow.Location = new System.Drawing.Point(35, 13);
            this.gpHow.Name = "gpHow";
            this.gpHow.Size = new System.Drawing.Size(337, 61);
            this.gpHow.TabIndex = 0;
            this.gpHow.TabStop = false;
            this.gpHow.Text = "Chon Cach";
            // 
            // rdMa
            // 
            this.rdMa.AutoSize = true;
            this.rdMa.Location = new System.Drawing.Point(55, 34);
            this.rdMa.Name = "rdMa";
            this.rdMa.Size = new System.Drawing.Size(57, 17);
            this.rdMa.TabIndex = 0;
            this.rdMa.TabStop = true;
            this.rdMa.Text = "Ma SV";
            this.rdMa.UseVisualStyleBackColor = true;
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Location = new System.Drawing.Point(153, 34);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(53, 17);
            this.rdName.TabIndex = 1;
            this.rdName.TabStop = true;
            this.rdName.Text = "Name";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // rdBD
            // 
            this.rdBD.AutoSize = true;
            this.rdBD.Location = new System.Drawing.Point(230, 34);
            this.rdBD.Name = "rdBD";
            this.rdBD.Size = new System.Drawing.Size(74, 17);
            this.rdBD.TabIndex = 2;
            this.rdBD.TabStop = true;
            this.rdBD.Text = "Ngay Sinh";
            this.rdBD.UseVisualStyleBackColor = true;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.tbThongTin);
            this.gbInput.Controls.Add(this.lblInput);
            this.gbInput.Location = new System.Drawing.Point(35, 80);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(256, 47);
            this.gbInput.TabIndex = 1;
            this.gbInput.TabStop = false;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(7, 20);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(85, 13);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Nhap Thong Tin";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(297, 95);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Tim";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbThongTin
            // 
            this.tbThongTin.Location = new System.Drawing.Point(113, 13);
            this.tbThongTin.Name = "tbThongTin";
            this.tbThongTin.Size = new System.Drawing.Size(121, 20);
            this.tbThongTin.TabIndex = 1;
            this.tbThongTin.TextChanged += new System.EventHandler(this.tbThongTin_TextChanged);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(69, 149);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Xap xep";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(235, 149);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 4;
            this.btnOut.Text = "Thoat";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // Optionfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 196);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.gpHow);
            this.Name = "Optionfrm";
            this.Text = "Optionfrm";
            this.Load += new System.EventHandler(this.Optionfrm_Load);
            this.gpHow.ResumeLayout(false);
            this.gpHow.PerformLayout();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpHow;
        private System.Windows.Forms.RadioButton rdBD;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.RadioButton rdMa;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.TextBox tbThongTin;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnOut;
    }
}