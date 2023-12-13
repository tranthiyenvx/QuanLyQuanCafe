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
    public partial class frmDoanhThuNhanVien : Form
    {
        public frmDoanhThuNhanVien()
        {
            InitializeComponent();
        }
        BUS_ThongKe BUS_TK = new BUS_ThongKe();
        private void frmDoanhThuNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            grdDoanhThu.AllowUserToAddRows = false;
            grdDoanhThu.DataSource = BUS_TK.ThongKeDoanhThuNhanVien(dateTimePicker1.Value, dateTimePicker2.Value);
            grdDoanhThu.Columns[0].HeaderText = "Mã nhân viên";
            grdDoanhThu.Columns[1].HeaderText = "Tên nhân viên";
            grdDoanhThu.Columns[2].HeaderText = "Tổng tiền";
            grdDoanhThu.Columns[0].Width = 200;
            grdDoanhThu.Columns[1].Width = 250;
            grdDoanhThu.Columns[2].Width = 225;

            if (grdDoanhThu.Rows.Count == 0)
            {
                lblTongTien.Text = "0 VND";
                lblTongTien.ForeColor = SystemColors.HotTrack;
                return;
            }
            int tien = grdDoanhThu.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += decimal.Parse(grdDoanhThu.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            lblTongTien.Text = thanhtien.ToString("#,###") + " VND";
            if (lblTongTien.Text == " VND")
            {
                lblTongTien.Text = "0 VND";
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < grdDoanhThu.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = grdDoanhThu.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < grdDoanhThu.Rows.Count; i++)
            {
                for (int j = 0; j < grdDoanhThu.Columns.Count; j++)
                {
                    if (grdDoanhThu.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = grdDoanhThu.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }
    }
}
