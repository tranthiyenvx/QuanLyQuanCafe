using BUS;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmManHinhChinh : Form
    {
        BUS_KhachHang BUS_KH = new BUS_KhachHang();
        BUS_HoaDon BUS_HD = new BUS_HoaDon();
        DTO_HoaDon DTO_HD = new DTO_HoaDon();
        public static bool luu = true;
        public static string MaDo_Uong_DonGia = "";
        public static string MaHD_Luu = "";
        public static string MaBan_Luu = "";
        public static string MaKH_Luu = "";
        public static string MaDo_Uong_Luu = "";
        public static string MaTK_NV_Luu = "";
        public static decimal DonGia_Luu;
        public static decimal SoLuong_Luu;
        public static string ma_kh_search = "";
        public static bool showbutton = false;
        public frmManHinhChinh()
        {
            InitializeComponent();
        }

        private void menutk_nv_Click(object sender, EventArgs e)
        {
            frmThongTin_NhanVien frm = new frmThongTin_NhanVien();
            frm.ShowDialog();
        }

        private void menuttcn_Click(object sender, EventArgs e)
        {
            frmThongTin_CaNhan frm = new frmThongTin_CaNhan();
            frm.ShowDialog();
        }

        private void menudo_uong_Click(object sender, EventArgs e)
        {
            frmDoUong frm = new frmDoUong();
            frm.ShowDialog();
        }

        private void menukhach_hang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
        }

        private void menuban_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan();
            frm.ShowDialog();
        }

        private void menudoanh_thu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            frm.ShowDialog();
        }

        private void menu_lich_su_hd_Click(object sender, EventArgs e)
        {
            frmLichSuHoaDon frm = new frmLichSuHoaDon();
            frm.ShowDialog();
        }

        private void menudang_xuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn đăng xuất chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void frmManHinhChinh_Load(object sender, EventArgs e)
        {
            if(frmDangNhap.Quyen_Luu == "NGUOIDUNG")
            {
                menutk_nv.Enabled = false;
                menuban.Enabled = false;
                menudo_uong.Enabled = false;
                menudoanh_thu.Enabled = false;
                thốngKêDoanhThuTheoToolStripMenuItem.Enabled = false;
                báoCáoDoanhThuToolStripMenuItem.Enabled = false;
                tínhLươngToolStripMenuItem.Enabled = false;
            }    
            btnBanDaChon.Text = "";
            txtMaTK_NV.Text = frmDangNhap.MaTK_NV_Luu;
            DanhSachKhachHang();
            DanhSachBan();
            DanhSachHoaDon(btnBanDaChon.Text);
            MaKH_Luu = cboMaKH.SelectedValue.ToString();
        }
        public void Tien()
        {
            if (grdHoaDon.Rows.Count == 0)
            {
                lblTongTien.Text = "0 VNĐ";
                return;
            }
            int tien = grdHoaDon.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += decimal.Parse(grdHoaDon.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            lblTongTien.Text = thanhtien.ToString("#,###") + "VNĐ";
            if (lblTongTien.Text == " VNĐ")
            {
                lblTongTien.Text = "0 VNĐ";
            }
        }
        private void DanhSachHoaDon(string MaBan)
        {
            DataTable dt = new DataTable();
            dt = BUS_HD.DanhSachHoaDon(MaBan);
            grdHoaDon.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string MaHD = dt.Rows[i]["MaHD"].ToString();
                string HinhAnh = dt.Rows[i]["HinhAnh"].ToString();
                string TenDo_Uong = dt.Rows[i]["TenDo_Uong"].ToString();
                string DonGia = dt.Rows[i]["DonGia"].ToString();
                string SoLuong = dt.Rows[i]["SoLuong"].ToString();
                string ThanhTien = dt.Rows[i]["ThanhTien"].ToString();
                if (HinhAnh != "")
                {
                    System.Drawing.Image img = ConvertStringtoImage(dt.Rows[i]["HinhAnh"].ToString());
                    grdHoaDon.Rows.Add(new object[] { MaHD, img, TenDo_Uong, DonGia, SoLuong, ThanhTien });
                }
                else
                {
                    grdHoaDon.Rows.Add(new object[] { MaHD, null, TenDo_Uong, DonGia, SoLuong, ThanhTien });
                    foreach (var column in grdHoaDon.Columns)
                    {
                        if (column is DataGridViewImageColumn)
                            (column as DataGridViewImageColumn).DefaultCellStyle.NullValue = null;
                    }
                }
            }
            foreach (DataGridViewRow r in grdHoaDon.Rows)
                r.Height = 60;
            grdHoaDon.Columns["MaHD"].Visible = false;

        }
        public System.Drawing.Image ConvertStringtoImage(string commands)
        {
            byte[] photoarray = Convert.FromBase64String(commands);
            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
            ms.Write(photoarray, 0, photoarray.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        public void DanhSachBan()
        {
            DataTable dtBan = new DataTable();
            listViewBan.Items.Clear();
            dtBan = BUS_HD.Table_No();
            for (int i = 0; i < dtBan.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dtBan.Rows[i]["TenBan"].ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, dtBan.Rows[i][0].ToString());
                item.ImageIndex = 0;
                item.SubItems.Add(subItem);
                listViewBan.Items.Add(item);
            }
            dtBan = BUS_HD.Table_Yes();
            for (int i = 0; i < dtBan.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dtBan.Rows[i]["TenBan"].ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, dtBan.Rows[i][0].ToString());
                item.ImageIndex = 1;
                item.SubItems.Add(subItem);
                listViewBan.Items.Add(item);
            }
        }
        private void DanhSachKhachHang()
        {
            DataTable dt = BUS_KH.DanhSachKhachHang();
            cboMaKH.DataSource = dt;
            cboMaKH.DisplayMember = "TenKH";
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.SelectedIndex = 0;
        }
       

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(btnBanDaChon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bàn để gọi món", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            luu = true;
            MaKH_Luu = cboMaKH.SelectedValue.ToString();
            frmHoaDon_Sua frm = new frmHoaDon_Sua();
            frm.Text = "Hóa đơn mới";
            frm.ShowDialog();
            DanhSachHoaDon(MaBan_Luu);
            DanhSachBan();
            Tien();
        }

        private void listViewBan_Click(object sender, EventArgs e)
        {
            string MaBan = listViewBan.SelectedItems[0].SubItems[0].Text;
            btnBanDaChon.Text = MaBan;
            MaBan_Luu = listViewBan.SelectedItems[0].SubItems[1].Text;
            DanhSachHoaDon(MaBan_Luu);
            Tien();
           
        }

        private void grdHoaDon_Click(object sender, EventArgs e)
        {
            
        }

        private void grdHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdHoaDon.Rows[e.RowIndex];
                DataTable dtHoaDon = BUS_HD.HoaDonTheoMa(row.Cells[0].Value.ToString());
                cboMaKH.SelectedValue = dtHoaDon.Rows[0]["MaKH"].ToString();
            }
        }

        private void cboMaDo_Uong_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnBanDaChon.Text = "";
            txtMaTK_NV.Text = frmDangNhap.MaTK_NV_Luu;
            DanhSachKhachHang();
            DanhSachBan();
            DanhSachHoaDon(btnBanDaChon.Text);
            MaKH_Luu = cboMaKH.SelectedValue.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdHoaDon.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.grdHoaDon.Rows[grdHoaDon.CurrentCell.RowIndex];
            luu = false;
            frmHoaDon_Sua frm = new frmHoaDon_Sua();
            MaHD_Luu = row.Cells[0].Value.ToString();
            MaDo_Uong_Luu = row.Cells[2].Value.ToString();
            DonGia_Luu = decimal.Parse(row.Cells[3].Value.ToString() + "");
            SoLuong_Luu = decimal.Parse(row.Cells[4].Value.ToString() + "");
            frm.Text = "Sửa món";
            frm.ShowDialog();
            DanhSachHoaDon(MaBan_Luu);
            DanhSachBan();
            Tien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdHoaDon.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc xóa món này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DTO_HD.MaHD = grdHoaDon.Rows[grdHoaDon.CurrentCell.RowIndex].Cells[0].Value.ToString();
                BUS_HD.Xoa(DTO_HD, grdHoaDon.Rows[grdHoaDon.CurrentCell.RowIndex].Cells["SoLuong"].Value.ToString());
                MessageBox.Show("Xóa xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DanhSachHoaDon(MaBan_Luu);
                DanhSachBan();
                Tien();
            }
            else
                return;
        }
        public static string tongtienin;
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (grdHoaDon.Rows.Count == 0)
            {
                return;
            }
            try
            {
                DialogResult ok = new DialogResult();
                ok = MessageBox.Show("Tính tiền cho bàn " + btnBanDaChon.Text + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    MessageBox.Show("Tổng tiền là " + lblTongTien.Text, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    tongtienin = lblTongTien.Text;
                    frmInPhieu frm = new frmInPhieu();
                    frm.ShowDialog();

                    Tien();
                    string s = "UPDATE HoaDon SET TrangThai = '1' WHERE MaBan = '"+MaBan_Luu+"'";
                    KetNoiSQL.ExecuteNonQuery(s);
                    DanhSachBan();
                    DanhSachHoaDon(MaBan_Luu);
                    Tien();
                }
                else
                {
                    return;
                }
            }
            catch { MessageBox.Show("Bạn chưa chọn bàn thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBanDaChon_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcLoạiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêDoanhThuTheoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanhThuNhanVien frm = new frmDoanhThuNhanVien();
            frm.ShowDialog();
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanhThuHangHoaBan frm = new frmDoanhThuHangHoaBan();
            frm.ShowDialog();
        }

        private void btnChonKH_Click(object sender, EventArgs e)
        {
            showbutton = true;
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
            frmManHinhChinh.showbutton = false;
            if (frmManHinhChinh.ma_kh_search.Trim() != "")
            {
                cboMaKH.SelectedValue = frmManHinhChinh.ma_kh_search;
                frmManHinhChinh.ma_kh_search = "";
            }    
        }

        private void listViewBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChamCong frm = new frmChamCong();
            frm.ShowDialog();
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTinhLuong frm = new frmTinhLuong();
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
