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
    public partial class frmThongTin_NhanVien : Form
    {
        BUS_TaiKhoan_NhanVien BUS = new BUS_TaiKhoan_NhanVien();
        DTO_TaiKhoan_NhanVien DTO = new DTO_TaiKhoan_NhanVien();
        public static bool luu = true;
        public static string MaTK_NV = "";
        public static string TenTK_NV = "";
        public static string MatKhau = "";
        public static string SoDienThoai = "";
        public static string DiaChi = "";
        public static string Quyen = "";
        public static string ChucVu = "";
        public static string HeSoLuong = "";
        public frmThongTin_NhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            luu = true;
            frmThongTin_NhanVien_Sua frm =new frmThongTin_NhanVien_Sua(this.grdTK_NV);
            frm.Text = "Thêm tài khoản/nhân viên";
            frm.ShowDialog();
        }

        private void frmThongTin_NhanVien_Load(object sender, EventArgs e)
        {
            DanhSachTaiKhoan_NhanVien();
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
        private void DanhSachTaiKhoan_NhanVien ()
        {
            grdTK_NV.AllowUserToAddRows = false;
            grdTK_NV.DataSource = BUS.DanhSachTaiKhoan_NhanVien();
            grdTK_NV.Columns[0].HeaderText = "Mã tài khoản/nhân viên";
            grdTK_NV.Columns[1].HeaderText = "Tên tài khoản/nhân viên";
            grdTK_NV.Columns[2].HeaderText = "Số điện thoại";
            grdTK_NV.Columns[3].HeaderText = "Địa chỉ";
            grdTK_NV.Columns[4].HeaderText = "Quyền";
            grdTK_NV.Columns[5].HeaderText = "Chức Vụ";
            grdTK_NV.Columns[6].HeaderText = "Hệ số lương";
            grdTK_NV.Columns[0].Width = 100;
            grdTK_NV.Columns[1].Width = 125;
            grdTK_NV.Columns[2].Width = 100;
            grdTK_NV.Columns[3].Width = 170;
            grdTK_NV.Columns[4].Width = 100;
            grdTK_NV.Columns[5].Width = 125;
            grdTK_NV.Columns[6].Width = 125;
        }
        private void grdTK_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdTK_NV.Rows[e.RowIndex];
                txtMaTK_NV.Text = row.Cells[0].Value.ToString();
                txtTenTK_NV.Text = row.Cells[1].Value.ToString();
                txtSoDienThoai.Text = row.Cells[2].Value.ToString();
                DataTable dt = BUS.LayMatKhau(txtMaTK_NV.Text.Trim());
                txtMatKhau.Text = dt.Rows[0]["MatKhau"].ToString();
                txtDiaChi.Text = row.Cells[3].Value.ToString();
                cboQuyen.SelectedValue = row.Cells[4].Value.ToString();
                txtChucVu.Text = row.Cells[5].Value.ToString();
                txtHeSoLuong.Text = row.Cells[6].Value.ToString();

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS.DanhSachTimKiem(txtMaTK_NV.Text, txtTenTK_NV.Text, txtSoDienThoai.Text, txtDiaChi.Text, txtChucVu.Text,txtHeSoLuong.Text);
            dt.Columns.Remove("MatKhau");
            grdTK_NV.DataSource = dt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < grdTK_NV.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = grdTK_NV.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < grdTK_NV.Rows.Count; i++)
            {
                for (int j = 0; j < grdTK_NV.Columns.Count; j++)
                {
                    if (grdTK_NV.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = grdTK_NV.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            grdTK_NV.DataSource = BUS.DanhSachTaiKhoan_NhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdTK_NV.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa dòng dữ liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DTO.MaTK_NV = grdTK_NV.Rows[grdTK_NV.CurrentCell.RowIndex].Cells[0].Value.ToString();
                BUS.Xoa(DTO);
                MessageBox.Show("Đã xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                grdTK_NV.DataSource = BUS.DanhSachTaiKhoan_NhanVien();
            }
            else
                return;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdTK_NV.Rows[grdTK_NV.CurrentCell.RowIndex];
            luu = false;
            frmThongTin_NhanVien_Sua frm = new frmThongTin_NhanVien_Sua(this.grdTK_NV);
            MaTK_NV = row.Cells[0].Value.ToString();
            TenTK_NV = row.Cells[1].Value.ToString();
            MatKhau = frmDangNhap.MatKhau_Luu;
            SoDienThoai = row.Cells[2].Value.ToString();
            DiaChi = row.Cells[3].Value.ToString();
            Quyen = row.Cells[4].Value.ToString();
            ChucVu = row.Cells[5].Value.ToString();
            HeSoLuong = row.Cells[6].Value.ToString();
            frm.Text = "Sửa tài khoản";
            frm.ShowDialog();
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaTK_NV.Text = "";
            txtTenTK_NV.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtChucVu.Text = "";
            txtHeSoLuong.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
