
namespace GUI
{
    partial class frmDoUong_Sua
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.nmSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.nmDonGia = new System.Windows.Forms.NumericUpDown();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDo_Uong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDo_Uong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnChonHinh = new System.Windows.Forms.LinkLabel();
            this.btnXoa = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(264, 275);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(129, 37);
            this.btnThoat.TabIndex = 40;
            this.btnThoat.Text = "Hủy";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Olive;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuu.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(107, 275);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(149, 37);
            this.btnLuu.TabIndex = 39;
            this.btnLuu.Text = "Lưu thông tin";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // nmSoLuongTon
            // 
            this.nmSoLuongTon.Location = new System.Drawing.Point(245, 166);
            this.nmSoLuongTon.Margin = new System.Windows.Forms.Padding(4);
            this.nmSoLuongTon.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmSoLuongTon.Name = "nmSoLuongTon";
            this.nmSoLuongTon.Size = new System.Drawing.Size(189, 22);
            this.nmSoLuongTon.TabIndex = 51;
            this.nmSoLuongTon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmDonGia
            // 
            this.nmDonGia.Location = new System.Drawing.Point(245, 121);
            this.nmDonGia.Margin = new System.Windows.Forms.Padding(4);
            this.nmDonGia.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmDonGia.Name = "nmDonGia";
            this.nmDonGia.Size = new System.Drawing.Size(189, 22);
            this.nmDonGia.TabIndex = 50;
            this.nmDonGia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(245, 215);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(187, 22);
            this.txtGhiChu.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "Đơn vị tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Số lượng tồn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Đơn giá";
            // 
            // txtTenDo_Uong
            // 
            this.txtTenDo_Uong.Location = new System.Drawing.Point(245, 79);
            this.txtTenDo_Uong.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDo_Uong.Name = "txtTenDo_Uong";
            this.txtTenDo_Uong.Size = new System.Drawing.Size(187, 22);
            this.txtTenDo_Uong.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Tên đồ uống";
            // 
            // txtMaDo_Uong
            // 
            this.txtMaDo_Uong.Location = new System.Drawing.Point(245, 37);
            this.txtMaDo_Uong.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaDo_Uong.Name = "txtMaDo_Uong";
            this.txtMaDo_Uong.Size = new System.Drawing.Size(187, 22);
            this.txtMaDo_Uong.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Mã đồ uống";
            // 
            // pcHinhAnh
            // 
            this.pcHinhAnh.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pcHinhAnh.Location = new System.Drawing.Point(503, 37);
            this.pcHinhAnh.Margin = new System.Windows.Forms.Padding(4);
            this.pcHinhAnh.Name = "pcHinhAnh";
            this.pcHinhAnh.Size = new System.Drawing.Size(319, 188);
            this.pcHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcHinhAnh.TabIndex = 52;
            this.pcHinhAnh.TabStop = false;
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.AutoSize = true;
            this.btnChonHinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonHinh.Location = new System.Drawing.Point(576, 240);
            this.btnChonHinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(83, 21);
            this.btnChonHinh.TabIndex = 53;
            this.btnChonHinh.TabStop = true;
            this.btnChonHinh.Text = "Chọn hình";
            this.btnChonHinh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnChonHinh_LinkClicked);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.LinkColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(683, 240);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(74, 20);
            this.btnXoa.TabIndex = 54;
            this.btnXoa.TabStop = true;
            this.btnXoa.Text = "Xóa hình";
            this.btnXoa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnXoa_LinkClicked);
            // 
            // frmDoUong_Sua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 329);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnChonHinh);
            this.Controls.Add(this.pcHinhAnh);
            this.Controls.Add(this.nmSoLuongTon);
            this.Controls.Add(this.nmDonGia);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenDo_Uong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaDo_Uong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDoUong_Sua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDoUong_Sua";
            this.Load += new System.EventHandler(this.frmDoUong_Sua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.NumericUpDown nmSoLuongTon;
        private System.Windows.Forms.NumericUpDown nmDonGia;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenDo_Uong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaDo_Uong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pcHinhAnh;
        private System.Windows.Forms.LinkLabel btnChonHinh;
        private System.Windows.Forms.LinkLabel btnXoa;
    }
}