using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ThongKe
    {
        public DataTable XemLaiHoaDon(DateTime ngay1, DateTime ngay2, string MaBan)
        {
            DAL_ThongKe DAL = new DAL_ThongKe();
            DataTable dtList = DAL.XemLaiHoaDon(ngay1, ngay2, MaBan);
            return dtList;
        }
        public DataTable ThongKeDoanhThu(DateTime ngay1, DateTime ngay2)
        {
            DAL_ThongKe DAL = new DAL_ThongKe();
            DataTable dtList = DAL.ThongKeDoanhThu(ngay1, ngay2);
            return dtList;
        }
        public DataTable ThongKeDoanhThuNhanVien(DateTime ngay1, DateTime ngay2)
        {
            DAL_ThongKe DAL = new DAL_ThongKe();
            DataTable dtList = DAL.ThongKeDoanhThuNhanVien(ngay1, ngay2);
            return dtList;
        }
        public DataTable ThongKeHangHoaBanRa(DateTime ngay1, DateTime ngay2)
        {
            DAL_ThongKe DAL = new DAL_ThongKe();
            DataTable dtList = DAL.ThongKeHangHoaBanRa(ngay1, ngay2);
            return dtList;
        }
    }
}
