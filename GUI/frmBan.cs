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
    public partial class frmBan : Form
    {
        BUS_Ban BUS = new BUS_Ban();
        DTO_Ban DTO = new DTO_Ban();
        public static bool luu = true;
        public static string MaBan = "";
        public static string TenBan = "";
        public static decimal SoLuongNguoi;
        public static string GhiChu = "";
        public frmBan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            luu = true;
            frmBan_Sua frm = new frmBan_Sua(this.grdBan);
            frm.Text = "Thêm bàn";
            frm.ShowDialog();
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            DanhSachBan();
        }
        private void DanhSachBan()
        {
            grdBan.AllowUserToAddRows = false;
            grdBan.DataSource = BUS.DanhSachBan();
            grdBan.Columns[0].HeaderText = "Mã bàn";
            grdBan.Columns[1].HeaderText = "Tên bàn";
            grdBan.Columns[2].HeaderText = "Số lượng";
            grdBan.Columns[3].HeaderText = "Ghi chú";
            grdBan.Columns[0].Width = 175;
            grdBan.Columns[1].Width = 175;
            grdBan.Columns[2].Width = 150;
            grdBan.Columns[3].Width = 220;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdBan.Rows[grdBan.CurrentCell.RowIndex];
            luu = false;
            frmBan_Sua frm = new frmBan_Sua(this.grdBan);
            MaBan = row.Cells[0].Value.ToString();
            TenBan = row.Cells[1].Value.ToString();
            SoLuongNguoi = decimal.Parse(row.Cells[2].Value.ToString() + "");
            GhiChu = row.Cells[3].Value.ToString();
            frm.Text = "Sửa bàn";
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdBan.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa dòng dữ liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DTO.MaBan = grdBan.Rows[grdBan.CurrentCell.RowIndex].Cells[0].Value.ToString();
                BUS.Xoa(DTO);
                MessageBox.Show("Đã xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                grdBan.DataSource = BUS.DanhSachBan();
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
            for (int i = 1; i < grdBan.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = grdBan.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < grdBan.Rows.Count; i++)
            {
                for (int j = 0; j < grdBan.Columns.Count; j++)
                {
                    if (grdBan.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = grdBan.Rows[i].Cells[j].Value.ToString();
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
            grdBan.DataSource = BUS.DanhSachBan();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS.DanhSachTimKiem(txtMaBan.Text, txtTenBan.Text, txtSLNguoi.Text, txtGhiChu.Text);
            grdBan.DataSource = dt;
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaBan.Text = "";
            txtTenBan.Text = "";
            txtSLNguoi.Text = "";
            txtGhiChu.Text = "";
        }

        private void grdBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdBan.Rows[e.RowIndex];
                txtMaBan.Text = row.Cells[0].Value.ToString();
                txtTenBan.Text = row.Cells[1].Value.ToString();
                txtSLNguoi.Text = row.Cells[2].Value.ToString();
                txtGhiChu.Text = row.Cells[3].Value.ToString();
            }
        }

        private void grdBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
