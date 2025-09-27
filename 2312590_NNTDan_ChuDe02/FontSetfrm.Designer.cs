namespace MyForm
{
    partial class FontSetfrm
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
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.nSize = new System.Windows.Forms.NumericUpDown();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblFont = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFont
            // 
            this.cbFont.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cbFont.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFont.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Items.AddRange(new object[] {
            "FC Cotton Cloud",
            "FC Milk Kids",
            "Sans Serif Collection"});
            this.cbFont.Location = new System.Drawing.Point(86, 9);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(215, 52);
            this.cbFont.TabIndex = 0;
            // 
            // nSize
            // 
            this.nSize.Location = new System.Drawing.Point(87, 104);
            this.nSize.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.nSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nSize.Name = "nSize";
            this.nSize.Size = new System.Drawing.Size(214, 20);
            this.nSize.TabIndex = 1;
            this.nSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Regular",
            "Oblique",
            "Bold"});
            this.cbType.Location = new System.Drawing.Point(87, 77);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(214, 21);
            this.cbType.TabIndex = 2;
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(19, 9);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(28, 13);
            this.lblFont.TabIndex = 3;
            this.lblFont.Text = "Font";
            this.lblFont.Click += new System.EventHandler(this.lblFont_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(16, 77);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type";
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.Location = new System.Drawing.Point(19, 110);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(27, 13);
            this.lblS.TabIndex = 5;
            this.lblS.Text = "Size";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(226, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FontSetfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 172);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblS);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.nSize);
            this.Controls.Add(this.cbFont);
            this.Name = "FontSetfrm";
            this.Text = "FontSetfrm";
            this.Load += new System.EventHandler(this.FontSetfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFont;
        private System.Windows.Forms.NumericUpDown nSize;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}