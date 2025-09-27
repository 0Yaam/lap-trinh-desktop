namespace MyForm
{
    partial class QuanLySVCNTTfrm
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
            this.components = new System.ComponentModel.Container();
            this.gpTTSV = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnMacDinh = new System.Windows.Forms.Button();
            this.btnChonHinh = new System.Windows.Forms.Button();
            this.tbDuongDan = new System.Windows.Forms.TextBox();
            this.mtbSDT = new System.Windows.Forms.MaskedTextBox();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.tbDiaChi = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.dtpNSinh = new System.Windows.Forms.DateTimePicker();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblGT = new System.Windows.Forms.Label();
            this.lblNSinh = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.tbMS = new System.Windows.Forms.TextBox();
            this.lblH = new System.Windows.Forms.Label();
            this.lblDC = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMS = new System.Windows.Forms.Label();
            this.gbDanhSach = new System.Windows.Forms.GroupBox();
            this.lvDanhSach = new System.Windows.Forms.ListView();
            this.chMS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGioiTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNSinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbHinh = new System.Windows.Forms.PictureBox();
            this.tsmiXoa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xoaSVDaChonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taiLaiDanhSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpTTSV.SuspendLayout();
            this.gbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinh)).BeginInit();
            this.tsmiXoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpTTSV
            // 
            this.gpTTSV.Controls.Add(this.btnThoat);
            this.gpTTSV.Controls.Add(this.btnLuu);
            this.gpTTSV.Controls.Add(this.btnMacDinh);
            this.gpTTSV.Controls.Add(this.btnChonHinh);
            this.gpTTSV.Controls.Add(this.tbDuongDan);
            this.gpTTSV.Controls.Add(this.mtbSDT);
            this.gpTTSV.Controls.Add(this.cbLop);
            this.gpTTSV.Controls.Add(this.tbDiaChi);
            this.gpTTSV.Controls.Add(this.tbEmail);
            this.gpTTSV.Controls.Add(this.rdNu);
            this.gpTTSV.Controls.Add(this.rdNam);
            this.gpTTSV.Controls.Add(this.dtpNSinh);
            this.gpTTSV.Controls.Add(this.lblSDT);
            this.gpTTSV.Controls.Add(this.lblLop);
            this.gpTTSV.Controls.Add(this.lblGT);
            this.gpTTSV.Controls.Add(this.lblNSinh);
            this.gpTTSV.Controls.Add(this.tbTen);
            this.gpTTSV.Controls.Add(this.tbMS);
            this.gpTTSV.Controls.Add(this.lblH);
            this.gpTTSV.Controls.Add(this.lblDC);
            this.gpTTSV.Controls.Add(this.label2);
            this.gpTTSV.Controls.Add(this.label1);
            this.gpTTSV.Controls.Add(this.lblMS);
            this.gpTTSV.Location = new System.Drawing.Point(223, 13);
            this.gpTTSV.Name = "gpTTSV";
            this.gpTTSV.Size = new System.Drawing.Size(565, 210);
            this.gpTTSV.TabIndex = 0;
            this.gpTTSV.TabStop = false;
            this.gpTTSV.Text = "Thong tin sinh vien";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(425, 179);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(313, 179);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Luu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnMacDinh
            // 
            this.btnMacDinh.Location = new System.Drawing.Point(202, 179);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(75, 23);
            this.btnMacDinh.TabIndex = 10;
            this.btnMacDinh.Text = "Mac Dinh";
            this.btnMacDinh.UseVisualStyleBackColor = true;
            this.btnMacDinh.Click += new System.EventHandler(this.btnMacDinh_Click);
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.Location = new System.Drawing.Point(441, 153);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(75, 23);
            this.btnChonHinh.TabIndex = 9;
            this.btnChonHinh.Text = "Chon Hinh";
            this.btnChonHinh.UseVisualStyleBackColor = true;
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click);
            // 
            // tbDuongDan
            // 
            this.tbDuongDan.Location = new System.Drawing.Point(67, 153);
            this.tbDuongDan.Name = "tbDuongDan";
            this.tbDuongDan.ReadOnly = true;
            this.tbDuongDan.Size = new System.Drawing.Size(339, 20);
            this.tbDuongDan.TabIndex = 13;
            // 
            // mtbSDT
            // 
            this.mtbSDT.Location = new System.Drawing.Point(359, 122);
            this.mtbSDT.Mask = "0000.000.000";
            this.mtbSDT.Name = "mtbSDT";
            this.mtbSDT.Size = new System.Drawing.Size(100, 20);
            this.mtbSDT.TabIndex = 8;
            // 
            // cbLop
            // 
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Items.AddRange(new object[] {
            "CTK43",
            "CTK44",
            "CTK45",
            "CTK46"});
            this.cbLop.Location = new System.Drawing.Point(359, 93);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(121, 21);
            this.cbLop.TabIndex = 7;
            // 
            // tbDiaChi
            // 
            this.tbDiaChi.Location = new System.Drawing.Point(67, 122);
            this.tbDiaChi.Name = "tbDiaChi";
            this.tbDiaChi.Size = new System.Drawing.Size(210, 20);
            this.tbDiaChi.TabIndex = 3;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(67, 95);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(210, 20);
            this.tbEmail.TabIndex = 2;
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(441, 63);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(39, 17);
            this.rdNu.TabIndex = 6;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nu";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Location = new System.Drawing.Point(359, 63);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(47, 17);
            this.rdNam.TabIndex = 5;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // dtpNSinh
            // 
            this.dtpNSinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNSinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNSinh.Location = new System.Drawing.Point(359, 24);
            this.dtpNSinh.Name = "dtpNSinh";
            this.dtpNSinh.Size = new System.Drawing.Size(200, 20);
            this.dtpNSinh.TabIndex = 4;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(283, 122);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(75, 13);
            this.lblSDT.TabIndex = 0;
            this.lblSDT.Text = "So Dien Thoai";
            this.lblSDT.Click += new System.EventHandler(this.lblSDT_Click);
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(283, 95);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(25, 13);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lop";
            // 
            // lblGT
            // 
            this.lblGT.AutoSize = true;
            this.lblGT.Location = new System.Drawing.Point(283, 63);
            this.lblGT.Name = "lblGT";
            this.lblGT.Size = new System.Drawing.Size(45, 13);
            this.lblGT.TabIndex = 0;
            this.lblGT.Text = "Gioi tinh";
            this.lblGT.Click += new System.EventHandler(this.lblGT_Click);
            // 
            // lblNSinh
            // 
            this.lblNSinh.AutoSize = true;
            this.lblNSinh.Location = new System.Drawing.Point(283, 31);
            this.lblNSinh.Name = "lblNSinh";
            this.lblNSinh.Size = new System.Drawing.Size(56, 13);
            this.lblNSinh.TabIndex = 0;
            this.lblNSinh.Text = "Ngay Sinh";
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(67, 60);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(210, 20);
            this.tbTen.TabIndex = 1;
            // 
            // tbMS
            // 
            this.tbMS.Location = new System.Drawing.Point(67, 24);
            this.tbMS.MaxLength = 7;
            this.tbMS.Name = "tbMS";
            this.tbMS.Size = new System.Drawing.Size(210, 20);
            this.tbMS.TabIndex = 0;
            this.tbMS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMS_KeyPress);
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Location = new System.Drawing.Point(6, 153);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(29, 13);
            this.lblH.TabIndex = 0;
            this.lblH.Text = "Hinh";
            // 
            // lblDC
            // 
            this.lblDC.AutoSize = true;
            this.lblDC.Location = new System.Drawing.Point(6, 122);
            this.lblDC.Name = "lblDC";
            this.lblDC.Size = new System.Drawing.Size(40, 13);
            this.lblDC.TabIndex = 0;
            this.lblDC.Text = "Dia chi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ho va ten";
            // 
            // lblMS
            // 
            this.lblMS.AutoSize = true;
            this.lblMS.Location = new System.Drawing.Point(6, 32);
            this.lblMS.Name = "lblMS";
            this.lblMS.Size = new System.Drawing.Size(37, 13);
            this.lblMS.TabIndex = 0;
            this.lblMS.Text = "MSSV";
            // 
            // gbDanhSach
            // 
            this.gbDanhSach.Controls.Add(this.lvDanhSach);
            this.gbDanhSach.Location = new System.Drawing.Point(13, 242);
            this.gbDanhSach.Name = "gbDanhSach";
            this.gbDanhSach.Size = new System.Drawing.Size(769, 187);
            this.gbDanhSach.TabIndex = 0;
            this.gbDanhSach.TabStop = false;
            this.gbDanhSach.Text = "Danh sach sinh vien";
            // 
            // lvDanhSach
            // 
            this.lvDanhSach.CheckBoxes = true;
            this.lvDanhSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMS,
            this.chTen,
            this.chGioiTinh,
            this.chNSinh,
            this.chLop,
            this.chSDT,
            this.chEmail,
            this.chDiaChi,
            this.chHinh});
            this.lvDanhSach.ContextMenuStrip = this.tsmiXoa;
            this.lvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDanhSach.GridLines = true;
            this.lvDanhSach.HideSelection = false;
            this.lvDanhSach.Location = new System.Drawing.Point(3, 16);
            this.lvDanhSach.Name = "lvDanhSach";
            this.lvDanhSach.Size = new System.Drawing.Size(763, 168);
            this.lvDanhSach.TabIndex = 0;
            this.lvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lvDanhSach.View = System.Windows.Forms.View.Details;
            this.lvDanhSach.SelectedIndexChanged += new System.EventHandler(this.lvDanhSach_SelectedIndexChanged);
            // 
            // chMS
            // 
            this.chMS.Text = "MSSV";
            this.chMS.Width = 61;
            // 
            // chTen
            // 
            this.chTen.Text = "Ho Ten";
            this.chTen.Width = 83;
            // 
            // chGioiTinh
            // 
            this.chGioiTinh.Text = "Gioi Tinh";
            this.chGioiTinh.Width = 55;
            // 
            // chNSinh
            // 
            this.chNSinh.Text = "Ngay Sinh";
            this.chNSinh.Width = 100;
            // 
            // chLop
            // 
            this.chLop.Text = "Lop";
            // 
            // chSDT
            // 
            this.chSDT.Text = "So Dien Thoai";
            this.chSDT.Width = 88;
            // 
            // chEmail
            // 
            this.chEmail.Text = "Email";
            this.chEmail.Width = 90;
            // 
            // chDiaChi
            // 
            this.chDiaChi.Text = "Dia Chi";
            this.chDiaChi.Width = 100;
            // 
            // chHinh
            // 
            this.chHinh.Text = "Hinh";
            this.chHinh.Width = 120;
            // 
            // pbHinh
            // 
            this.pbHinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbHinh.Location = new System.Drawing.Point(16, 13);
            this.pbHinh.Name = "pbHinh";
            this.pbHinh.Size = new System.Drawing.Size(189, 210);
            this.pbHinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHinh.TabIndex = 3;
            this.pbHinh.TabStop = false;
            // 
            // tsmiXoa
            // 
            this.tsmiXoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoaToolStripMenuItem,
            this.xoaSVDaChonToolStripMenuItem,
            this.taiLaiDanhSachToolStripMenuItem});
            this.tsmiXoa.Name = "tsmiXoa";
            this.tsmiXoa.Size = new System.Drawing.Size(162, 70);
            this.tsmiXoa.Opening += new System.ComponentModel.CancelEventHandler(this.tsmiXoa_Opening);
            // 
            // xoaToolStripMenuItem
            // 
            this.xoaToolStripMenuItem.Name = "xoaToolStripMenuItem";
            this.xoaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xoaToolStripMenuItem.Text = "Xoa";
            this.xoaToolStripMenuItem.Click += new System.EventHandler(this.xoaToolStripMenuItem_Click);
            // 
            // xoaSVDaChonToolStripMenuItem
            // 
            this.xoaSVDaChonToolStripMenuItem.Name = "xoaSVDaChonToolStripMenuItem";
            this.xoaSVDaChonToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xoaSVDaChonToolStripMenuItem.Text = "Xoa SV Da Chon";
            this.xoaSVDaChonToolStripMenuItem.Click += new System.EventHandler(this.xoaSVDaChonToolStripMenuItem_Click);
            // 
            // taiLaiDanhSachToolStripMenuItem
            // 
            this.taiLaiDanhSachToolStripMenuItem.Name = "taiLaiDanhSachToolStripMenuItem";
            this.taiLaiDanhSachToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.taiLaiDanhSachToolStripMenuItem.Text = "Tai lai danh sach";
            this.taiLaiDanhSachToolStripMenuItem.Click += new System.EventHandler(this.taiLaiDanhSachToolStripMenuItem_Click);
            // 
            // QuanLySVCNTTfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 437);
            this.Controls.Add(this.pbHinh);
            this.Controls.Add(this.gbDanhSach);
            this.Controls.Add(this.gpTTSV);
            this.Name = "QuanLySVCNTTfrm";
            this.Text = "QuanLySVCNTTfrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLySVCNTTfrm_FormClosing);
            this.Load += new System.EventHandler(this.QuanLySVCNTTfrm_Load);
            this.gpTTSV.ResumeLayout(false);
            this.gpTTSV.PerformLayout();
            this.gbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHinh)).EndInit();
            this.tsmiXoa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gpTTSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMS;
        private System.Windows.Forms.TextBox tbMS;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblDC;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblGT;
        private System.Windows.Forms.Label lblNSinh;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.DateTimePicker dtpNSinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.TextBox tbDiaChi;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.MaskedTextBox mtbSDT;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnMacDinh;
        private System.Windows.Forms.Button btnChonHinh;
        private System.Windows.Forms.TextBox tbDuongDan;
        private System.Windows.Forms.GroupBox gbDanhSach;
        private System.Windows.Forms.ListView lvDanhSach;
        private System.Windows.Forms.ColumnHeader chMS;
        private System.Windows.Forms.ColumnHeader chTen;
        private System.Windows.Forms.ColumnHeader chGioiTinh;
        private System.Windows.Forms.ColumnHeader chNSinh;
        private System.Windows.Forms.ColumnHeader chLop;
        private System.Windows.Forms.ColumnHeader chSDT;
        private System.Windows.Forms.ColumnHeader chEmail;
        private System.Windows.Forms.ColumnHeader chDiaChi;
        private System.Windows.Forms.ColumnHeader chHinh;
        private System.Windows.Forms.PictureBox pbHinh;
        private System.Windows.Forms.ContextMenuStrip tsmiXoa;
        private System.Windows.Forms.ToolStripMenuItem xoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xoaSVDaChonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taiLaiDanhSachToolStripMenuItem;
    }
}