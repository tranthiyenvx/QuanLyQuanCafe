using BUS;
using DAL;
using DTO;
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
    public partial class frmThongTin_CaNhan : Form
    {
        BUS_TaiKhoan_NhanVien BUS = new BUS_TaiKhoan_NhanVien();
        DTO_TaiKhoan_NhanVien DTO = new DTO_TaiKhoan_NhanVien();
        public frmThongTin_CaNhan()
        {
            InitializeComponent();
        }

        private void frmThongTin_CaNhan_Load(object sender, EventArgs e)
        {
            DanhSachQuyen();
            DataTable dt = BUS.ThongTinTaiKhoanCaNhan(frmDangNhap.MaTK_NV_Luu);
            txtMaTK_NV.Text = dt.Rows[0]["MaTK_NV"].ToString();
            txtTenTK_NV.Text = dt.Rows[0]["TenTK_NV"].ToString();
            txtSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
            txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            cboQuyen.SelectedValue = dt.Rows[0]["Quyen"].ToString(); 
        }
        private void DanhSachQuyen()
        {
            DataTable dt = BUS.DanhSachQuyen();
            cboQuyen.DataSource = dt;
            cboQuyen.DisplayMember = "TenQuyen";
            cboQuyen.ValueMember = "MaQuyen";
            cboQuyen.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMatKhau_Cu.Text == "")
            {
                MessageBox.Show("Mật khẩu cũ không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau_Cu.Focus();
                return;
            }
            if (txtMatKhau_Moi.Text == "")
            {
                MessageBox.Show("Mật khẩu mới không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau_Moi.Focus();
                return;
            }
            if ((txtMatKhau_Moi.Text != txtMatKhau_NhapLai.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau_Moi.Focus();
                return;
            }
            if (txtMatKhau_Cu.Text != frmDangNhap.MatKhau_Luu)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau_Cu.Focus();
                return;
            }
            string strSQL = string.Format(@"UPDATE TaiKhoan_NhanVien set MatKhau = '" + txtMatKhau_Moi.Text + "' where MaTK_NV = '" + txtMaTK_NV.Text + "'");
            KetNoiSQL.ExecuteNonQuery(strSQL);
            MessageBox.Show("Đổi mật khẩu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            this.Close();
        }
    }
}
