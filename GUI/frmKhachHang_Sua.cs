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
    public partial class frmKhachHang_Sua : Form
    {
        protected DataGridView gridView;
        BUS_KhachHang BUS = new BUS_KhachHang();
        DTO_KhachHang DTO = new DTO_KhachHang();
        public frmKhachHang_Sua(DataGridView dtgridView)
        {
            InitializeComponent();
            gridView = dtgridView;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Tên khách hàng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
                return;
            }
            if (frmKhachHang.luu == true)
            {
                if (KiemTraTrung(txtMaKH.Text) == 1)
                {
                    MessageBox.Show("Không lưu được, Khách hàng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaKH = txtMaKH.Text;
                DTO.TenKH = txtTenKH.Text;
                DTO.SoDienThoai = txtSoDienThoai.Text;
                DTO.DiaChi = txtDiaChi.Text;
                BUS.Them(DTO);
                MessageBox.Show("Thêm xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                gridView.DataSource = BUS.DanhSachKhachHang();
                this.Close();
            }
            else if (frmKhachHang.luu == false)
            {
                if (KiemTraTrung(txtMaKH.Text) == 1 && txtMaKH.Text != frmKhachHang.MaKH)
                {
                    MessageBox.Show("Không lưu được, Khách hàng này đã tồn tại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaKH_Sua = frmKhachHang.MaKH;
                DTO.MaKH = txtMaKH.Text;
                DTO.TenKH = txtTenKH.Text;
                DTO.SoDienThoai = txtSoDienThoai.Text;
                DTO.DiaChi = txtDiaChi.Text;

                BUS.Sua(DTO);
                MessageBox.Show("Sửa xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                gridView.DataSource = BUS.DanhSachKhachHang();
                this.Close();
            }
        }
        private int KiemTraTrung(string MaTK_NV)
        {
            if (BUS.KiemTraTrung(MaTK_NV) == 1)
                return 0;
            return 1;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKhachHang_Sua_Load(object sender, EventArgs e)
        {
            if (frmKhachHang.luu == false)
            {
                txtMaKH.Text = frmKhachHang.MaKH;
                txtTenKH.Text = frmKhachHang.TenKH;
                txtSoDienThoai.Text = frmKhachHang.SoDienThoai;
                txtDiaChi.Text = frmKhachHang.DiaChi;
            }
        }
    }
}
