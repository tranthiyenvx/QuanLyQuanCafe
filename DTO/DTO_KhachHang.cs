using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        public static string _MaKH;
        public static string _MaKH_Sua;
        public static string _TenKH;
        public static string _SoDienThoai;
        public static string _DiaChi;

        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        public string MaKH_Sua
        {
            get { return _MaKH_Sua; }
            set { _MaKH_Sua = value; }
        }
        public string TenKH
        {
            get { return _TenKH; }
            set { _TenKH = value; }
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
    }
}
