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
    public partial class frmHoaDon_Sua : Form
    {
        protected DataGridView gridView;
        BUS_KhachHang BUS_KH = new BUS_KhachHang();
        DTO_KhachHang DTO_KH = new DTO_KhachHang();
        BUS_DoUong BUS_DoUong = new BUS_DoUong();
        DTO_DoUong DTO_DoUong = new DTO_DoUong();
        BUS_HoaDon BUS_HD = new BUS_HoaDon();
        DTO_HoaDon DTO_HD = new DTO_HoaDon();
        public frmHoaDon_Sua()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Sua_Load(object sender, EventArgs e)
        {
            if(frmManHinhChinh.luu == true)
            {
                DanhSachDoUong();
                //Mã tự tăng
                string sTemp = DateTime.Now.ToString("yyMMddhhmmss");
                string sBarcode = sTemp;
                int iSum = 0;
                int iDigit = 0;
                for (int i = sTemp.Length; i >= 1; i += -1)
                {
                    iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                    if (i % 2 == 0)
                    {
                        iSum += iDigit * 3;
                    }
                    else
                    {
                        iSum += iDigit * 1;
                    }
                }
                int iCheckSum = (10 - (iSum % 10)) % 10;
                sBarcode = sBarcode + iCheckSum.ToString();
                txtMaHD.Text = sBarcode;
            }   
            else
            {
                txtMaHD.Text = frmManHinhChinh.MaHD_Luu;
                cboMaDo_Uong.SelectedValue = frmManHinhChinh.MaDo_Uong_Luu;
                DanhSachDoUong();
                txtMaHD.Text = frmManHinhChinh.MaHD_Luu;
                nmDonGia.Value = frmManHinhChinh.DonGia_Luu;
                nmSoLuong.Value = frmManHinhChinh.SoLuong_Luu;
            }    
        }
        private void DanhSachDoUong()
        {
            DataTable dt = BUS_DoUong.DanhSachDoUong();
            cboMaDo_Uong.DataSource = dt;
            cboMaDo_Uong.DisplayMember = "TenDo_Uong";
            cboMaDo_Uong.ValueMember = "MaDo_Uong";
            cboMaDo_Uong.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BUS_HD.KiemTraSoLuongTon(cboMaDo_Uong.SelectedValue.ToString());
            if(decimal.Parse(dt.Rows[0]["SoLuongTon"].ToString()) < nmSoLuong.Value)
            {
                MessageBox.Show("Không đủ số lượng để bán, số lượng tồn còn lại là "+ dt.Rows[0]["SoLuongTon"].ToString() + "");
                return;
            }    
            if (frmManHinhChinh.luu == true)
            {
                DTO_HD.MaHD = txtMaHD.Text;
                DTO_HD.MaBan = frmManHinhChinh.MaBan_Luu;
                DTO_HD.MaKH = frmManHinhChinh.MaKH_Luu;
                DTO_HD.MaTK_NV = frmDangNhap.MaTK_NV_Luu;
                DTO_HD.MaDo_Uong = cboMaDo_Uong.SelectedValue.ToString();
                DTO_HD.DonGia = nmDonGia.Value;
                DTO_HD.SoLuong = nmSoLuong.Value;
                DTO_HD.ThanhTien = nmDonGia.Value * nmSoLuong.Value;
                BUS_HD.Them(DTO_HD,nmSoLuong.Value.ToString());
                MessageBox.Show("Thêm xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                
                this.Close();
            }
            else
            {
                DTO_HD.MaHD = txtMaHD.Text;
                DTO_HD.MaBan = frmManHinhChinh.MaBan_Luu;
                DTO_HD.MaKH = frmManHinhChinh.MaKH_Luu;
                DTO_HD.MaTK_NV = frmDangNhap.MaTK_NV_Luu;
                DTO_HD.MaDo_Uong = cboMaDo_Uong.SelectedValue.ToString();
                DTO_HD.DonGia = nmDonGia.Value;
                DTO_HD.SoLuong = nmSoLuong.Value;
                DTO_HD.ThanhTien = nmDonGia.Value * nmSoLuong.Value;
                BUS_HD.Sua(DTO_HD, frmManHinhChinh.SoLuong_Luu.ToString(), nmSoLuong.Value.ToString());
                MessageBox.Show("Sửa xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                
                this.Close();
            }
        }

        private void cboMaDo_Uong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGia = BUS_DoUong.DanhSachDoUongTheoGia(cboMaDo_Uong.SelectedValue.ToString());
                nmDonGia.Value = decimal.Parse(dtGia.Rows[0]["DonGia"].ToString() + "");
            }
            catch
            {
                DanhSachDoUong();
                DataTable dtGia = BUS_DoUong.DanhSachDoUongTheoGia(cboMaDo_Uong.SelectedValue.ToString());
                nmDonGia.Value = decimal.Parse(dtGia.Rows[0]["DonGia"].ToString() + "");
            }
        }
    }
}
