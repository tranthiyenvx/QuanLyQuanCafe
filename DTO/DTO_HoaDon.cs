using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDon
    {
        public static string _MaHD;
        public static string _MaBan;
        public static string _MaKH;
        public static string _MaTK_NV;
        public static DateTime _NgayHoaDon;
        public static decimal _TongTien;
        public static string _TrangThai;
        public static string _MaDo_Uong;
        public static decimal _DonGia;
        public static decimal _SoLuong;
        public static decimal _ThanhTien;

        public decimal DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        public decimal SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        public decimal ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
        public string MaDo_Uong
        {
            get { return _MaDo_Uong; }
            set { _MaDo_Uong = value; }
        }
        public string TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
        public decimal TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
        public DateTime NgayHoaDon
        {
            get { return _NgayHoaDon; }
            set { _NgayHoaDon = value; }
        }
        public string MaTK_NV
        {
            get { return _MaTK_NV; }
            set { _MaTK_NV = value; }
        }
        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        public string MaHD
        {
            get { return _MaHD; }
            set { _MaHD = value; }
        }
        public string MaBan
        {
            get { return _MaBan; }
            set { _MaBan = value; }
        }
    }
}
