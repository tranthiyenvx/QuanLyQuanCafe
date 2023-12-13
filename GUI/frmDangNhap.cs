using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        BUS_TaiKhoan_NhanVien BUS = new BUS_TaiKhoan_NhanVien();
        public static string MaTK_NV_Luu = "";
        public static string MatKhau_Luu = "";
        public static string Quyen_Luu = "";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMaDangNhap.Text == "")
            {
                MessageBox.Show("Mã đăng nhập không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            if (BUS.DangNhapChuongTrinh(txtMaDangNhap.Text, txtMatKhau.Text, cboQuyen.SelectedValue.ToString()) == null || BUS.DangNhapChuongTrinh(txtMaDangNhap.Text, txtMatKhau.Text, cboQuyen.SelectedValue.ToString()).Rows.Count == 0)
            {
                MessageBox.Show("Thông tin tài khoản không đúng", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //this.Hide();
            frmManHinhChinh f = new frmManHinhChinh();
            MaTK_NV_Luu = txtMaDangNhap.Text;
            MatKhau_Luu = txtMatKhau.Text;
            Quyen_Luu = cboQuyen.SelectedValue.ToString();
            f.Show();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            DanhSachQuyen();
        }
        private void DanhSachQuyen()
        {
            DataTable dt = BUS.DanhSachQuyen();
            cboQuyen.DataSource = dt;
            cboQuyen.DisplayMember = "TenQuyen";
            cboQuyen.ValueMember = "MaQuyen";
            cboQuyen.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
