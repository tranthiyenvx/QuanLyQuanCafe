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
    public partial class frmLichSuHoaDon : Form
    {
        BUS_ThongKe BUS_TK = new BUS_ThongKe();
        BUS_Ban BUS_Ban = new BUS_Ban();
        public frmLichSuHoaDon()
        {
            InitializeComponent();
        }
        private void DanhSachBan()
        {
            DataTable dt = BUS_Ban.DanhSachBan();
            cboMaBan.DataSource = dt;
            cboMaBan.DisplayMember = "TenBan";
            cboMaBan.ValueMember = "MaBan";
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            grdHoaDon.AllowUserToAddRows = false;
            grdHoaDon.DataSource = BUS_TK.XemLaiHoaDon(dateTimePicker1.Value, dateTimePicker2.Value, cboMaBan.SelectedValue.ToString());
            grdHoaDon.Columns[0].HeaderText = "Ngày hóa đơn";
            grdHoaDon.Columns[1].HeaderText = "Tên bàn";
            grdHoaDon.Columns[2].HeaderText = "Tên khách hàng";
            grdHoaDon.Columns[3].HeaderText = "Tên đồ uống";
            grdHoaDon.Columns[4].HeaderText = "Đơn giá";
            grdHoaDon.Columns[5].HeaderText = "Số lượng";
            grdHoaDon.Columns[6].HeaderText = "Thành tiền";

            grdHoaDon.Columns[0].Width = 100;
            grdHoaDon.Columns[1].Width = 100;
            grdHoaDon.Columns[2].Width = 150;
            grdHoaDon.Columns[3].Width = 150;
            grdHoaDon.Columns[4].Width = 100;
            grdHoaDon.Columns[5].Width = 100;
            grdHoaDon.Columns[6].Width = 100;
            if (grdHoaDon.Rows.Count == 0)
            {
                lblTongTien.Text = "0 VND";
                lblTongTien.ForeColor = SystemColors.HotTrack;
                return;
            }
            int tien = grdHoaDon.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += decimal.Parse(grdHoaDon.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            lblTongTien.Text = thanhtien.ToString("#,###") + " VND";
            if (lblTongTien.Text == " VND")
            {
                lblTongTien.Text = "0 VND";
            }
        }

        private void frmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            DanhSachBan();
        }
    }
}
