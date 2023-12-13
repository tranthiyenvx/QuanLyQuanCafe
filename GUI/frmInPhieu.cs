using BUS;
using Microsoft.Reporting.WinForms;
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
    public partial class frmInPhieu : Form
    {

        public frmInPhieu()
        {
            InitializeComponent();
        }
        BUS_HoaDon BUS_HD = new BUS_HoaDon();
        private void frmInPhieu_Load(object sender, EventArgs e)
        {

            DataTable dt = BUS_HD.InHoaDon(frmManHinhChinh.MaBan_Luu);
            DataTable dt2 = BUS_HD.InHoaDonThongTinChung(frmManHinhChinh.MaBan_Luu);

            reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.ReportInHD.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("TenKH", dt2.Rows[0][0].ToString(), true);
            parameters[1] = new ReportParameter("TenTK_NV", dt2.Rows[0][1].ToString(), true);
            parameters[2] = new ReportParameter("NgayHD", dt2.Rows[0][2].ToString(), true);
            parameters[3] = new ReportParameter("TongTien", frmManHinhChinh.tongtienin, true);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
