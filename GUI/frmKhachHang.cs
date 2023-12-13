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
    public partial class frmKhachHang : Form
    {
        BUS_KhachHang BUS = new BUS_KhachHang();
        DTO_KhachHang DTO = new DTO_KhachHang();
        public static bool luu = true;
        public static string MaKH = "";
        public static string TenKH = "";
        public static string SoDienThoai;
        public static string DiaChi = "";
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            luu = true;
            frmKhachHang_Sua frm = new frmKhachHang_Sua(this.grdKH);
            frm.Text = "Thêm khách hàng";
            frm.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS.DanhSachTimKiem(txtMaKH.Text, txtTenKH.Text, txtSoDienThoai.Text, txtDiaChi.Text);
            grdKH.DataSource = dt;
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaKH.Text ="";
            txtTenKH.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdKH.Rows[grdKH.CurrentCell.RowIndex];
            luu = false;
            frmKhachHang_Sua frm = new frmKhachHang_Sua(this.grdKH);
            MaKH = row.Cells[0].Value.ToString();
            TenKH = row.Cells[1].Value.ToString();
            SoDienThoai = row.Cells[2].Value.ToString();
            DiaChi = row.Cells[3].Value.ToString();
            frm.Text = "Sửa khách hàng";
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdKH.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa dòng dữ liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DTO.MaKH = grdKH.Rows[grdKH.CurrentCell.RowIndex].Cells[0].Value.ToString();
                BUS.Xoa(DTO);
                MessageBox.Show("Đã xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                grdKH.DataSource = BUS.DanhSachKhachHang();
            }
            else
                return;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < grdKH.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = grdKH.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < grdKH.Rows.Count; i++)
            {
                for (int j = 0; j < grdKH.Columns.Count; j++)
                {
                    if (grdKH.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = grdKH.Rows[i].Cells[j].Value.ToString();
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
            grdKH.DataSource = BUS.DanhSachKhachHang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdKH.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtSoDienThoai.Text = row.Cells[2].Value.ToString();
                txtDiaChi.Text = row.Cells[3].Value.ToString();
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            if(frmManHinhChinh.showbutton == true)
            {
                btnChon.Visible = true;
            }    
            else
            {
                btnChon.Visible = false;
            }    
            DanhSachKhachHang();
        }
        private void DanhSachKhachHang()
        {
            grdKH.AllowUserToAddRows = false;
            grdKH.DataSource = BUS.DanhSachKhachHang();
            grdKH.Columns[0].HeaderText = "Mã khách hàng";
            grdKH.Columns[1].HeaderText = "Tên khách hàng";
            grdKH.Columns[2].HeaderText = "Số điện thoại";
            grdKH.Columns[3].HeaderText = "Địa chỉ";
            grdKH.Columns[0].Width = 150;
            grdKH.Columns[1].Width = 175;
            grdKH.Columns[2].Width = 150;
            grdKH.Columns[3].Width = 275;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (grdKH.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có khách hàng để chọn");
                return;
            }
            DataGridViewRow row = this.grdKH.Rows[grdKH.CurrentCell.RowIndex];
            frmManHinhChinh.ma_kh_search = row.Cells[0].Value.ToString();
            this.Close();
        }
    }
}
