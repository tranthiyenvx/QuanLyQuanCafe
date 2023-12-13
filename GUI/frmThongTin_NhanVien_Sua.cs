using BUS;
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
    public partial class frmThongTin_NhanVien_Sua : Form
    {
        protected DataGridView gridView;
        BUS_TaiKhoan_NhanVien BUS = new BUS_TaiKhoan_NhanVien();
        DTO_TaiKhoan_NhanVien DTO = new DTO_TaiKhoan_NhanVien();
        public frmThongTin_NhanVien_Sua(DataGridView dtgridView)
        {
            InitializeComponent();
            gridView = dtgridView;
        }

        private void frmTK_NV_Sua_Load(object sender, EventArgs e)
        {
            if (frmThongTin_NhanVien.luu == true)
            {
                DanhSachQuyen();
            }
            else
            {
                DanhSachQuyen();
                txtMaTK_NV.Text = frmThongTin_NhanVien.MaTK_NV;
                txtTenTK_NV.Text = frmThongTin_NhanVien.TenTK_NV;
                txtSoDienThoai.Text = frmThongTin_NhanVien.SoDienThoai;
                txtMatKhau.Text = frmThongTin_NhanVien.MatKhau;
                txtNhapLaiMatKhau.Text = frmThongTin_NhanVien.MatKhau;
                txtDiaChi.Text = frmThongTin_NhanVien.DiaChi;
                cboQuyen.SelectedValue = frmThongTin_NhanVien.Quyen;
                txtChucVu.Text = frmThongTin_NhanVien.ChucVu;
                nmHeSoLuong.Text = frmThongTin_NhanVien.HeSoLuong;

            }

        }
        private void DanhSachQuyen()
        {
            DataTable dt = BUS.DanhSachQuyen();
            cboQuyen.DataSource = dt;
            cboQuyen.DisplayMember = "TenQuyen";
            cboQuyen.ValueMember = "MaQuyen";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTK_NV.Text == "")
            {
                MessageBox.Show("Mã tài khoản/nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaTK_NV.Focus();
                return;
            }
            if (txtTenTK_NV.Text == "")
            {
                MessageBox.Show("Tên tài khoản/nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTK_NV.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            if ((txtMatKhau.Text != txtNhapLaiMatKhau.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapLaiMatKhau.Focus();
                return;
            }
            if (frmThongTin_NhanVien.luu == true)
            {
                if (KiemTraTrung(txtMaTK_NV.Text) == 1)
                {
                    MessageBox.Show("Không lưu được, Tài khoản/nhân viên này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaTK_NV = txtMaTK_NV.Text;
                DTO.TenTK_NV = txtTenTK_NV.Text;
                DTO.MatKhau = txtMatKhau.Text;
                DTO.SoDienThoai = txtSoDienThoai.Text;
                DTO.DiaChi = txtDiaChi.Text;
                DTO.Quyen = cboQuyen.SelectedValue.ToString();
                DTO.ChucVu = txtChucVu.Text;
                DTO.HeSoLuong = nmHeSoLuong.Text;
                BUS.Them(DTO);
                MessageBox.Show("Thêm xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                gridView.DataSource = BUS.DanhSachTaiKhoan_NhanVien();
                this.Close();
            }
            else if (frmThongTin_NhanVien.luu == false)
            {
                if (KiemTraTrung(txtMaTK_NV.Text) == 1 && txtMaTK_NV.Text != frmThongTin_NhanVien.MaTK_NV)
                {
                    MessageBox.Show("Không lưu được, Tài khoản này đã tồn tại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaTK_NV_Sua = frmThongTin_NhanVien.MaTK_NV;
                DTO.MaTK_NV = txtMaTK_NV.Text;
                DTO.TenTK_NV = txtTenTK_NV.Text;
                DTO.MatKhau = txtMatKhau.Text;
                DTO.SoDienThoai = txtSoDienThoai.Text;
                DTO.DiaChi = txtDiaChi.Text;
                DTO.Quyen = cboQuyen.SelectedValue.ToString();
                DTO.ChucVu = txtChucVu.Text;
                DTO.HeSoLuong = nmHeSoLuong.Text;
                BUS.Sua(DTO);
                MessageBox.Show("Sửa xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                gridView.DataSource = BUS.DanhSachTaiKhoan_NhanVien();
                this.Close();
            }
        }
        private int KiemTraTrung(string MaTK_NV)
        {
            if (BUS.KiemTraTrung(MaTK_NV) == 1)
                return 0;
            return 1;
        }
    }
}
