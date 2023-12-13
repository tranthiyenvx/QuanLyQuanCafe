using DAL;
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
    public partial class frmTinhLuong : Form
    {
        public frmTinhLuong()
        {
            InitializeComponent();
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            nmThang.Text = DateTime.Now.Month.ToString();
            nmNam.Text = DateTime.Now.Year.ToString();
            DanhSachLuong();
        }

       
        private void DanhSachLuong()
        {
            string sql = "SELECT a.MaTK_NV,b.TenTK_NV,a.Thang,a.Nam,a.TienLuong from TinhLuong a INNER JOIN TaiKhoan_NhanVien b ON a.MaTK_NV = b.MaTK_NV WHERE a.Thang LIKE '%"+nmThang.Text+"%' AND a.Nam LIKE '%"+nmNam.Text+"%' AND a.MaTK_NV LIKE '%" + txtMaNVSearch.Text + "%' AND TenTK_NV LIKE N'%" + txtTenNVSearch.Text + "%'";
            grdLuong.DataSource = KetNoiSQL.GetData(sql);
            grdLuong.Columns[0].HeaderText = "Mã nhân viên";
            grdLuong.Columns[1].HeaderText = "Tên nhân viên";
            grdLuong.Columns[2].HeaderText = "Tháng";
            grdLuong.Columns[3].HeaderText = "Năm";
            grdLuong.Columns[4].HeaderText = "Tiền lương";
            grdLuong.Columns[0].Width = 115;
            grdLuong.Columns[1].Width = 150;
            grdLuong.Columns[2].Width = 115;
            grdLuong.Columns[3].Width = 115;
            grdLuong.Columns[4].Width = 125;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DanhSachLuong();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Có chắc chắn tính lương cho toàn bộ nhân viên trong tháng " + nmThang.Text + " năm " + nmNam.Text + " hay không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string strSQL = "DELETE TinhLuong WHERE Thang =" + nmThang.Text + " AND Nam = " + nmNam.Text + "";
                    strSQL += "; INSERT INTO TinhLuong(MaTK_NV,Thang,Nam,TienLuong)";
                    strSQL += " SELECT MaTK_NV,Thang,YEAR(NgayLamViec),SUM(TongGioLam * HeSoLuong)   FROM ChamCong WHERE Thang = " + nmThang.Text + " AND year(NgayLamViec) = " + nmNam.Text + " GROUP BY MaTK_NV,Thang,YEAR(NgayLamViec)";
                    KetNoiSQL.ExecuteNonQuery(strSQL);
                    MessageBox.Show("Tính lương thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DanhSachLuong();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi rồi");
                    return;
                }

            }
            else
                return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < grdLuong.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = grdLuong.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < grdLuong.Rows.Count; i++)
            {
                for (int j = 0; j < grdLuong.Columns.Count; j++)
                {
                    if (grdLuong.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = grdLuong.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void grdLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
