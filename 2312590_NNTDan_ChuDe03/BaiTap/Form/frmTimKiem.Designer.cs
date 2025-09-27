namespace BaiTap
{
    partial class frmTimKiem
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
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cbbLocTheoLop = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdMSSV = new System.Windows.Forms.RadioButton();
            this.rdTen = new System.Windows.Forms.RadioButton();
            this.rdHoTenLot = new System.Windows.Forms.RadioButton();
            this.rdDiaChi = new System.Windows.Forms.RadioButton();
            this.rdCMND = new System.Windows.Forms.RadioButton();
            this.rdSDT = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(51, 54);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(456, 20);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // cbbLocTheoLop
            // 
            this.cbbLocTheoLop.FormattingEnabled = true;
            this.cbbLocTheoLop.Items.AddRange(new object[] {
            "None",
            "CTK44",
            "CTK45",
            "CTK46",
            "CTK47"});
            this.cbbLocTheoLop.Location = new System.Drawing.Point(419, 17);
            this.cbbLocTheoLop.Name = "cbbLocTheoLop";
            this.cbbLocTheoLop.Size = new System.Drawing.Size(88, 21);
            this.cbbLocTheoLop.TabIndex = 38;
            this.cbbLocTheoLop.Text = "Lớp";
            this.cbbLocTheoLop.SelectedIndexChanged += new System.EventHandler(this.cbbLocTheoLop_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.rdNu);
            this.groupBox1.Controls.Add(this.rdNam);
            this.groupBox1.Location = new System.Drawing.Point(513, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 71);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giới tính";
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(6, 39);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(39, 17);
            this.rdNu.TabIndex = 1;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            this.rdNu.CheckedChanged += new System.EventHandler(this.rdNu_CheckedChanged);
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Location = new System.Drawing.Point(6, 17);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(47, 17);
            this.rdNam.TabIndex = 0;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            this.rdNam.CheckedChanged += new System.EventHandler(this.rdNam_CheckedChanged);
            // 
            // rdMSSV
            // 
            this.rdMSSV.AutoSize = true;
            this.rdMSSV.Location = new System.Drawing.Point(9, 19);
            this.rdMSSV.Name = "rdMSSV";
            this.rdMSSV.Size = new System.Drawing.Size(55, 17);
            this.rdMSSV.TabIndex = 2;
            this.rdMSSV.TabStop = true;
            this.rdMSSV.Text = "MSSV";
            this.rdMSSV.UseVisualStyleBackColor = true;
            this.rdMSSV.CheckedChanged += new System.EventHandler(this.rdMSSV_CheckedChanged);
            // 
            // rdTen
            // 
            this.rdTen.AutoSize = true;
            this.rdTen.Location = new System.Drawing.Point(147, 19);
            this.rdTen.Name = "rdTen";
            this.rdTen.Size = new System.Drawing.Size(44, 17);
            this.rdTen.TabIndex = 40;
            this.rdTen.TabStop = true;
            this.rdTen.Text = "Tên";
            this.rdTen.UseVisualStyleBackColor = true;
            this.rdTen.CheckedChanged += new System.EventHandler(this.rdTen_CheckedChanged);
            // 
            // rdHoTenLot
            // 
            this.rdHoTenLot.AutoSize = true;
            this.rdHoTenLot.Location = new System.Drawing.Point(70, 19);
            this.rdHoTenLot.Name = "rdHoTenLot";
            this.rdHoTenLot.Size = new System.Drawing.Size(71, 17);
            this.rdHoTenLot.TabIndex = 41;
            this.rdHoTenLot.TabStop = true;
            this.rdHoTenLot.Text = "Họ tên lót";
            this.rdHoTenLot.UseVisualStyleBackColor = true;
            this.rdHoTenLot.CheckedChanged += new System.EventHandler(this.rdHoTenLot_CheckedChanged);
            // 
            // rdDiaChi
            // 
            this.rdDiaChi.AutoSize = true;
            this.rdDiaChi.Location = new System.Drawing.Point(323, 19);
            this.rdDiaChi.Name = "rdDiaChi";
            this.rdDiaChi.Size = new System.Drawing.Size(58, 17);
            this.rdDiaChi.TabIndex = 42;
            this.rdDiaChi.TabStop = true;
            this.rdDiaChi.Text = "Địa chỉ";
            this.rdDiaChi.UseVisualStyleBackColor = true;
            this.rdDiaChi.CheckedChanged += new System.EventHandler(this.rdDiaChi_CheckedChanged);
            // 
            // rdCMND
            // 
            this.rdCMND.AutoSize = true;
            this.rdCMND.Location = new System.Drawing.Point(250, 19);
            this.rdCMND.Name = "rdCMND";
            this.rdCMND.Size = new System.Drawing.Size(57, 17);
            this.rdCMND.TabIndex = 43;
            this.rdCMND.TabStop = true;
            this.rdCMND.Text = "CMND";
            this.rdCMND.UseVisualStyleBackColor = true;
            this.rdCMND.CheckedChanged += new System.EventHandler(this.rdCMND_CheckedChanged);
            // 
            // rdSDT
            // 
            this.rdSDT.AutoSize = true;
            this.rdSDT.Location = new System.Drawing.Point(197, 19);
            this.rdSDT.Name = "rdSDT";
            this.rdSDT.Size = new System.Drawing.Size(47, 17);
            this.rdSDT.TabIndex = 44;
            this.rdSDT.TabStop = true;
            this.rdSDT.Text = "SDT";
            this.rdSDT.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdMSSV);
            this.groupBox2.Controls.Add(this.rdSDT);
            this.groupBox2.Controls.Add(this.rdTen);
            this.groupBox2.Controls.Add(this.rdCMND);
            this.groupBox2.Controls.Add(this.rdHoTenLot);
            this.groupBox2.Controls.Add(this.rdDiaChi);
            this.groupBox2.Location = new System.Drawing.Point(16, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 42);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm theo";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(47, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(33, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 96);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbbLocTheoLop);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "frmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cbbLocTheoLop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdMSSV;
        private System.Windows.Forms.RadioButton rdTen;
        private System.Windows.Forms.RadioButton rdHoTenLot;
        private System.Windows.Forms.RadioButton rdDiaChi;
        private System.Windows.Forms.RadioButton rdCMND;
        private System.Windows.Forms.RadioButton rdSDT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
    }
}