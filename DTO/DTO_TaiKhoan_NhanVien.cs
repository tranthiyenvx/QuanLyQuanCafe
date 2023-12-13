using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan_NhanVien
    {
        public static string _MaTK_NV;
        public static string _MaTK_NV_Sua;
        public static string _TenTK_NV;
        public static string _MatKhau;
        public static string _SoDienThoai;
        public static string _DiaChi;
        public static string _Quyen;
        public static string _ChucVu;
        public static string _HeSoLuong;

        public string MaTK_NV
        {
            get { return _MaTK_NV; }
            set { _MaTK_NV = value; }
        }
        public string MaTK_NV_Sua
        {
            get { return _MaTK_NV_Sua; }
            set { _MaTK_NV_Sua = value; }
        }
        public string TenTK_NV
        {
            get { return _TenTK_NV; }
            set { _TenTK_NV = value; }
        }
        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        public string Quyen
        {
            get { return _Quyen; }
            set { _Quyen = value; }
        }
        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu= value; }
        }
        public DTO_TaiKhoan_NhanVien()
        {
            _MaTK_NV = "";
            _MatKhau = "";
        }
        public string HeSoLuong
        {
            get { return _HeSoLuong; }
            set { _HeSoLuong = value; }
        }
    }
}
