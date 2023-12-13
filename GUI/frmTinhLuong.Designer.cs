namespace GUI
{
    partial class frmTinhLuong
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
            this.nmNam = new System.Windows.Forms.NumericUpDown();
            this.nmThang = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTenNVSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNVSearch = new System.Windows.Forms.TextBox();
            this.grdLuong = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // nmNam
            // 
            this.nmNam.Location = new System.Drawing.Point(445, 76);
            this.nmNam.Margin = new System.Windows.Forms.Padding(4);
            this.nmNam.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nmNam.Name = "nmNam";
            this.nmNam.Size = new System.Drawing.Size(64, 23);
            this.nmNam.TabIndex = 488;
            this.nmNam.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmThang
            // 
            this.nmThang.Location = new System.Drawing.Point(286, 76);
            this.nmThang.Margin = new System.Windows.Forms.Padding(4);
            this.nmThang.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nmThang.Name = "nmThang";
            this.nmThang.Size = new System.Drawing.Size(64, 23);
            this.nmThang.TabIndex = 487;
            this.nmThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(389, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 486;
            this.label4.Text = "Năm";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(218, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 485;
            this.label3.Text = "Tháng";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(320, 113);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 20);
            this.label13.TabIndex = 484;
            this.label13.Text = "Tên nhân viên";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtTenNVSearch
            // 
            this.txtTenNVSearch.Location = new System.Drawing.Point(434, 113);
            this.txtTenNVSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNVSearch.Name = "txtTenNVSearch";
            this.txtTenNVSearch.Size = new System.Drawing.Size(171, 23);
            this.txtTenNVSearch.TabIndex = 483;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(22, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 481;
            this.label6.Text = "Mã nhân viên";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtMaNVSearch
            // 
            this.txtMaNVSearch.Location = new System.Drawing.Point(134, 113);
            this.txtMaNVSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNVSearch.Name = "txtMaNVSearch";
            this.txtMaNVSearch.Size = new System.Drawing.Size(171, 23);
            this.txtMaNVSearch.TabIndex = 480;
            // 
            // grdLuong
            // 
            this.grdLuong.AllowUserToAddRows = false;
            this.grdLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLuong.BackgroundColor = System.Drawing.Color.White;
            this.grdLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLuong.Location = new System.Drawing.Point(3, 156);
            this.grdLuong.Margin = new System.Windows.Forms.Padding(4);
            this.grdLuong.Name = "grdLuong";
            this.grdLuong.ReadOnly = true;
            this.grdLuong.RowHeadersWidth = 51;
            this.grdLuong.Size = new System.Drawing.Size(778, 355);
            this.grdLuong.TabIndex = 477;
            this.grdLuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLuong_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 28);
            this.label1.TabIndex = 489;
            this.label1.Text = "BẢNG TÍNH LƯƠNG ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTim.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(651, 102);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(109, 35);
            this.btnTim.TabIndex = 490;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(661, 527);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(109, 35);
            this.btnThoat.TabIndex = 491;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTinhLuong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTinhLuong.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhLuong.ForeColor = System.Drawing.Color.White;
            this.btnTinhLuong.Location = new System.Drawing.Point(3, 527);
            this.btnTinhLuong.Margin = new System.Windows.Forms.Padding(4);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(126, 35);
            this.btnTinhLuong.TabIndex = 492;
            this.btnTinhLuong.Text = "Tính lương ";
            this.btnTinhLuong.UseVisualStyleBackColor = false;
            this.btnTinhLuong.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXuat.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(161, 527);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(127, 35);
            this.btnXuat.TabIndex = 493;
            this.btnXuat.Text = "Xuất excel";
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 573);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmNam);
            this.Controls.Add(this.nmThang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTenNVSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaNVSearch);
            this.Controls.Add(this.grdLuong);
            this.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTinhLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính lương";
            this.Load += new System.EventHandler(this.frmTinhLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmNam;
        private System.Windows.Forms.NumericUpDown nmThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTenNVSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNVSearch;
        private System.Windows.Forms.DataGridView grdLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Button btnXuat;
    }
}