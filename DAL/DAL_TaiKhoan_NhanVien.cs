using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan_NhanVien
    {
        public DataTable DangNhapChuongTrinh(string MaTK_NV, string MatKhau, string Quyen)
        {
            string strSQL = "Select * From TaiKhoan_NhanVien Where MaTK_NV =  '" + MaTK_NV + "' And MatKhau = '" + MatKhau + "' And Quyen = '" + Quyen + "'";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable DanhSachQuyen()
        {
            return KetNoiSQL.GetData(string.Format("select * FROM Quyen"));
        }
        public DataTable DanhSachTaiKhoan_NhanVien()
        {
            return KetNoiSQL.GetData(string.Format("select MaTK_NV,TenTK_NV,SoDienThoai,DiaChi,Quyen,ChucVu,HeSoLuong FROM TaiKhoan_NhanVien"));
        }
        public DataTable ThongTinTaiKhoanCaNhan(String MaTK_NV)
        {
            return KetNoiSQL.GetData(string.Format("select MaTK_NV,TenTK_NV,SoDienThoai,DiaChi,Quyen,ChucVu FROM TaiKhoan_NhanVien WHERE MaTK_NV = '"+ MaTK_NV + "'"));
        }
        
        public DataTable LayMatKhau(string MaTK_NV)
        {
            return KetNoiSQL.GetData(string.Format("select * FROM TaiKhoan_NhanVien WHERE MaTK_NV = '" + MaTK_NV + "'"));
        }
        public DataTable DanhSachTimKiem(string MaTK_NV, string TenTK_NV, string SoDienThoai, string DiaChi, string ChucVu,string HeSoLuong)
        {
            return KetNoiSQL.GetData(string.Format("select * FROM TaiKhoan_NhanVien WHERE MaTK_NV LIKE N'%" + MaTK_NV + "%' AND TenTK_NV LIKE N'%" + TenTK_NV + "%' AND SoDienThoai LIKE N'%" + SoDienThoai + "%' AND DiaChi LIKE N'%" + DiaChi + "%' AND ChucVu LIKE N'%" + ChucVu + "%' AND HeSoLuong LIKE '%"+ HeSoLuong + "%'"));
        }
        public void Xoa(DTO_TaiKhoan_NhanVien MaTK_NV)
        {
            string strSQL = "DELETE TaiKhoan_NhanVien  where MaTK_NV = '" + MaTK_NV.MaTK_NV + "'";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Sua(DTO_TaiKhoan_NhanVien TK_NV)
        {
            string strSQL = string.Format(@"UPDATE TaiKhoan_NhanVien set HeSoLuong ="+TK_NV.HeSoLuong+",  MaTK_NV = '" + TK_NV.MaTK_NV + "', TenTK_NV = N'" + TK_NV.TenTK_NV + "',MatKhau = '" + TK_NV.MatKhau + "',SoDienThoai = '" + TK_NV.SoDienThoai + "',DiaChi = N'" + TK_NV.DiaChi + "',Quyen = '" + TK_NV.Quyen + "',ChucVu = N'" + TK_NV.ChucVu + "' where MaTK_NV = '" + TK_NV.MaTK_NV_Sua + "'");
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Them(DTO_TaiKhoan_NhanVien TK_NV)
        {
            string strSQL = "INSERT INTO TaiKhoan_NhanVien(MaTK_NV,TenTK_NV,MatKhau,SoDienThoai,DiaChi,Quyen,ChucVu,HeSoLuong)  VALUES ( '" + TK_NV.MaTK_NV + "',N'" + TK_NV.TenTK_NV + "','" + TK_NV.MatKhau + "',N'" + TK_NV.SoDienThoai + "',N'" + TK_NV.DiaChi + "','" + TK_NV.Quyen + "',N'" + TK_NV.ChucVu + "',"+TK_NV.HeSoLuong + ")";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public int KiemTraTrung(string MaTK_NV)
        {
            int i = 0;
            string strSQL = "SELECT * FROM TaiKhoan_NhanVien WHERE MaTK_NV = '" + MaTK_NV + "'";
            DataTable dt = KetNoiSQL.GetData(strSQL);
            if (dt == null || dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
    }
}
