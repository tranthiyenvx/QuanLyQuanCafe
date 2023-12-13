using BUS;
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
    public partial class frmDoUong_Sua : Form
    {
        protected DataGridView gridView;
        BUS_DoUong BUS = new BUS_DoUong();
        DTO_DoUong DTO = new DTO_DoUong();
        public frmDoUong_Sua()
        {
            InitializeComponent();
        }

        private void frmDoUong_Sua_Load(object sender, EventArgs e)
        {
            if (frmDoUong.luu == false)
            {
                txtMaDo_Uong.Text = frmDoUong.MaDo_Uong;
                txtTenDo_Uong.Text = frmDoUong.TenDo_Uong;
                nmDonGia.Value = frmDoUong.DonGia;
                nmSoLuongTon.Value = frmDoUong.SoLuongTon;
                txtGhiChu.Text = frmDoUong.GhiChu;

                DataTable dtimg = new DataTable();
                dtimg = BUS.HinhAnhDoUong(frmDoUong.MaDo_Uong);
                if (dtimg.Rows[0]["HinhAnh"].ToString() != "")
                {
                    pcHinhAnh.Image = ConvertStringtoImage(dtimg.Rows[0]["HinhAnh"].ToString());
                    dtHinhAnh = dtimg.Rows[0]["HinhAnh"].ToString();
                }
            }
            else
            {
                pcHinhAnh.Image = null;
                img2 = null;
                dtHinhAnh = "";
            }    
        }
        public System.Drawing.Image ConvertStringtoImage(string commands)
        {
            byte[] photoarray = Convert.FromBase64String(commands);
            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
            ms.Write(photoarray, 0, photoarray.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDo_Uong.Text == "")
            {
                MessageBox.Show("Mã đồ uống không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDo_Uong.Focus();
                return;
            }
            if (txtTenDo_Uong.Text == "")
            {
                MessageBox.Show("Tên đồ uống không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDo_Uong.Focus();
                return;
            }
            if (frmDoUong.luu == true)
            {
                if (KiemTraTrung(txtMaDo_Uong.Text) == 1)
                {
                    MessageBox.Show("Không lưu được, Đồ uống này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaDo_Uong = txtMaDo_Uong.Text;
                DTO.TenDo_Uong = txtTenDo_Uong.Text;
                DTO.DonGia = nmDonGia.Value;
                DTO.SoLuongTon = nmSoLuongTon.Value;
                DTO.GhiChu = txtGhiChu.Text;
                DTO.HinhAnh = dtHinhAnh;

                BUS.Them(DTO);
                MessageBox.Show("Thêm xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else if (frmDoUong.luu == false)
            {
                if (KiemTraTrung(txtMaDo_Uong.Text) == 1 && txtMaDo_Uong.Text != frmDoUong.MaDo_Uong)
                {
                    MessageBox.Show("Không lưu được, Tài khoản này đã tồn tại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO.MaDo_Uong_Sua = frmDoUong.MaDo_Uong;
                DTO.MaDo_Uong = txtMaDo_Uong.Text;
                DTO.TenDo_Uong = txtTenDo_Uong.Text;
                DTO.DonGia = nmDonGia.Value;
                DTO.SoLuongTon = nmSoLuongTon.Value;
                DTO.GhiChu = txtGhiChu.Text;
                DTO.HinhAnh = dtHinhAnh;
                try
                {
                    BUS.Sua(DTO);
                    MessageBox.Show("Sửa xong ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Dữ liệu đã phát sinh khóa ngoại, không sửa được.");
                    return;
                }
               
            }
        }
        private int KiemTraTrung(string MaDo_Uong)
        {
            if (BUS.KiemTraTrung(MaDo_Uong) == 1)
                return 0;
            return 1;
        }
        private Boolean choseImage = false;
        public static System.Drawing.Image img2;
        private string dtHinhAnh;
        private void btnChonHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            string filename;
            OpenFile.Multiselect = false;
            OpenFile.Filter = "Images (*.png, *.gif, *.tif, *.tiff, *.bmp, *.jpg, *.jpeg, *.jpe, *.jfif)|*.png;*.gif;*.tif;*.tiff;*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif";
            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = OpenFile.FileName;
                OpenFile.Dispose();
                if (filename != "")
                {
                    choseImage = true;
                    System.Drawing.Image img;
                    try
                    {
                        img = System.Drawing.Image.FromFile(filename);
                        if (img != null)
                        {
                            pcHinhAnh.Image = img;
                            img2 = img;
                            ImageConverter converter = new ImageConverter();
                            var bytes = (byte[])converter.ConvertTo((Bitmap)pcHinhAnh.Image, typeof(byte[]));
                            dtHinhAnh = Convert.ToBase64String(bytes);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void btnXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            choseImage = true;
            pcHinhAnh.Image = null;
            img2 = null;
            dtHinhAnh = "";
        }
    }
}
