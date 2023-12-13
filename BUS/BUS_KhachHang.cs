using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KhachHang
    {
        public DataTable DanhSachKhachHang()
        {
            DAL_KhachHang DAL = new DAL_KhachHang();
            return DAL.DanhSachKhachHang();
        }
        public DataTable DanhSachTimKiem(string MaKH, string TenKH, string SoDienThoai, string DiaChi)
        {
            DAL_KhachHang DAL = new DAL_KhachHang();
            DataTable dtList = DAL.DanhSachTimKiem(MaKH, TenKH, SoDienThoai, DiaChi);
            return dtList;
        }
        public void Xoa(DTO_KhachHang MaKH)
        {
            DAL_KhachHang DAL = new DAL_KhachHang();
            DAL.Xoa(MaKH);
        }
        public void Sua(DTO_KhachHang MaKH)
        {
            DAL_KhachHang DAL = new DAL_KhachHang();
            DAL.Sua(MaKH);
        }
        public void Them(DTO_KhachHang MaKH)
        {
            DAL_KhachHang DAL = new DAL_KhachHang();
            DAL.Them(MaKH);
        }
        public int KiemTraTrung(string MaKH)
        {
            DAL_KhachHang DAL = new DAL_KhachHang();
            int i = DAL.KiemTraTrung(MaKH);
            return i;
        }
    }
}
