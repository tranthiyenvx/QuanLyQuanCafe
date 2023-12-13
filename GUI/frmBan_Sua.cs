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
    public partial class frmBan_Sua : Form
    {
        protected DataGridView gridView;
        BUS_Ban BUS = new BUS_Ban();
        DTO_Ban DTO = new DTO_Ban();
        public frmBan_Sua(DataGridView dtgridView)
        {
            InitializeComponent();
            gridView = dtgridView;
        }

        private void frmBan_Sua_Load(object sender, EventArgs e)
        {
            if (frmBan.luu == false)
            {
                txtMaBan.Text = frmBan.MaBan;
                txtTenBan.Text = frmBan.TenBan;
                nmSoLuongNguoi.Value = frmBan.SoLuongNguoi;
                txtGhiChu.Text = frmBan.GhiChu;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaBan.Text == "")
            {
                MessageBox.Show("Mã bàn không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaBan.Focus();
                return;
            }
            if (txtTenBan.Text == "")
            {
                MessageBox.Show("Tên bàn không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenBan.Focus();
                return;
            }
            if (frmBan.luu == true)
            {
                if (KiemTraTrung(txtMaBan.Text) == 1)
                {
                    MessageBox.Show("Không lưu được, Bàn này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaBan = txtMaBan.Text;
                DTO.TenBan = txtTenBan.Text;
                DTO.SoLuongNguoi = nmSoLuongNguoi.Value;
                DTO.GhiChu = txtGhiChu.Text;

                BUS.Them(DTO);
                MessageBox.Show("Thêm xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                gridView.DataSource = BUS.DanhSachBan();
                this.Close();
            }
            else if (frmBan.luu == false)
            {
                if (KiemTraTrung(txtMaBan.Text) == 1 && txtMaBan.Text != frmBan.MaBan)
                {
                    MessageBox.Show("Không lưu được, Tài khoản này đã tồn tại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaBan_Sua = frmBan.MaBan;
                DTO.MaBan = txtMaBan.Text;
                DTO.TenBan = txtTenBan.Text;
                DTO.SoLuongNguoi = nmSoLuongNguoi.Value;
                DTO.GhiChu = txtGhiChu.Text;

                BUS.Sua(DTO);
                MessageBox.Show("Sửa xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                gridView.DataSource = BUS.DanhSachBan();
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
    }
}
