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
    public partial class frmChamCong : Form
    {
        public frmChamCong()
        {
            InitializeComponent();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            DanhSachChamCong();
            if (gridview.Rows.Count == 0)
            {
                string Query = "INSERT INTO ChamCong(MaTK_NV,Thang,NgayLamViec,GioVao,GioRa,TongGioLam)  VALUES ( '" + frmDangNhap.MaTK_NV_Luu + "'," + DateTime.Now.Month + ",'" + DateTime.Now.ToString("yyyyMMdd") + "',NULL,NULL,NULL)";
                KetNoiSQL.ExecuteNonQuery(Query);
                DanhSachChamCong();
            }
            var row = this.gridview.Rows[0];
            if (row.Cells[3].Value.ToString() != "")
            {
                btnCheckIn.Enabled = false;
            }
        }
        private void DanhSachChamCong()
        {
            gridview.DataSource = KetNoiSQL.GetData("SELECT * FROM ChamCong WHERE MaTK_NV = '" + frmDangNhap.MaTK_NV_Luu + "' AND Thang = " + DateTime.Now.Month + " AND NgayLamViec = '" + DateTime.Now.ToString("yyyyMMdd") + "'");
            gridview.Columns[0].HeaderText = "Mã nhân viên";
            gridview.Columns[1].HeaderText = "Tháng";
            gridview.Columns[2].HeaderText = "Ngày làm việc";
            gridview.Columns[3].HeaderText = "Giờ vào";
            gridview.Columns[4].HeaderText = "Giờ ra";
            gridview.Columns[5].HeaderText = "Tổng giờ làm";
            gridview.Columns[6].HeaderText = "Hệ số lương";
        }

           

        private void btnCheckIn_Click_2(object sender, EventArgs e)
        {
            string strSQL = "UPDATE ChamCong SET GioVao = '" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "' WHERE MaTK_NV = '" + frmDangNhap.MaTK_NV_Luu + "' AND Thang = " + DateTime.Now.Month + " AND NgayLamViec = '" + DateTime.Now.ToString("yyyyMMdd") + "' ";
            KetNoiSQL.ExecuteNonQuery(strSQL);
            MessageBox.Show("Check In thành công");
            DanhSachChamCong();
            btnCheckIn.Enabled = false;
        }

        private void btnCheckOut_Click_2(object sender, EventArgs e)
        {
            string strSQL = "UPDATE ChamCong SET GioRa = '" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "' WHERE MaTK_NV = '" + frmDangNhap.MaTK_NV_Luu + "' AND Thang = " + DateTime.Now.Month + " AND NgayLamViec = '" + DateTime.Now.ToString("yyyyMMdd") + "' ";
            KetNoiSQL.ExecuteNonQuery(strSQL);

            string strSQL2 = "UPDATE ChamCong SET TongGioLam = (DATEDIFF(HOUR, GioVao, GioRa)) WHERE MaTK_NV = '" + frmDangNhap.MaTK_NV_Luu + "' AND Thang = " + DateTime.Now.Month + " AND NgayLamViec = '" + DateTime.Now.ToString("yyyyMMdd") + "' ";
            KetNoiSQL.ExecuteNonQuery(strSQL2);

            string strSQL3 = "UPDATE ChamCong SET HeSoLuong = (SELECT HeSoLuong FROM TaiKhoan_NhanVien WHERE MaTK_NV = '" + frmDangNhap.MaTK_NV_Luu + "') WHERE MaTK_NV = '" + frmDangNhap.MaTK_NV_Luu + "' AND Thang = " + DateTime.Now.Month + " AND NgayLamViec = '" + DateTime.Now.ToString("yyyyMMdd") + "' ";
            KetNoiSQL.ExecuteNonQuery(strSQL3);

            MessageBox.Show("Check Out thành công");
            DanhSachChamCong();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
