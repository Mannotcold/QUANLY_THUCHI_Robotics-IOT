using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQLTHU_CHI
{
    public partial class Report : Form
    {

        List<Report> _list;
        //string _ngaylap;
            //, _khoahoc, _lophoc, _thu, _khachhang, _thanhtoan, _mahoadon;

        public Report()//string ngaylap)
        {
            InitializeComponent();
            //_ngaylap = ngaylap;
            //, string khoahoc, string lophoc, string thu, string khachhang, string thanhtoan, string mahoadon
            //_khoahoc = khoahoc;
            //_lophoc = lophoc;
            //_thu = thu;
            //_khachhang = khachhang;
            //_thanhtoan = thanhtoan;
            //_mahoadon = mahoadon;

        }
        private void Report_Load(object sender, EventArgs e)
        {
            //Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            //{
            //        new Microsoft.Reporting.WinForms.ReportParameter("ngaylap", _ngaylap) };
            //    new Microsoft.Reporting.WinForms.ReportParameter("khoahoc", _khoahoc),
            //    new Microsoft.Reporting.WinForms.ReportParameter("lophoc", _lophoc),
            //    new Microsoft.Reporting.WinForms.ReportParameter("thu", _thu),
            //    new Microsoft.Reporting.WinForms.ReportParameter("khachhang", _khachhang),
            //    new Microsoft.Reporting.WinForms.ReportParameter("thanhtoan", _thanhtoan),
            //    new Microsoft.Reporting.WinForms.ReportParameter("mahoadon", _mahoadon)
            //};

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PMQLTHU_CHI.ReportPhieuThuChi.rdlc";
            List<Report> parameters = new List<Report>();
            int a = 2240000;
            
            // Tạo đối tượng tham số và thêm vào danh sách
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pngaylap", "20/08/2002"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhoahoc", "20/08/2002"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("plophoc", "20/08/2002"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pthu", a.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhachhang", "20/08/2002"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pthanhtoan", "20/08/2002"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmahoadon", "20/08/2002"));
            //this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
