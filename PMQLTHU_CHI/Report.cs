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

        //List<Report> _list;
        string _ngaylap, _khoahoc, _lophoc, _thu, _khachhang, _thanhtoan, _mahoadon;

        public Report(string ngaylap, string khoahoc, string lophoc, string thu, string khachhang, string thanhtoan, string mahoadon)
        {
            InitializeComponent();
            _ngaylap = ngaylap;
            _khoahoc = khoahoc;
            _lophoc = lophoc;
            _thu = thu;
            _khachhang = khachhang;
            _thanhtoan = thanhtoan;
            _mahoadon = mahoadon;

        }
        private void Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PMQLTHU_CHI.ReportPhieuThuChi.rdlc";
            List<Report> parameters = new List<Report>();
            int a = 2240000;
            
            // Tạo đối tượng tham số và thêm vào danh sách
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pngaylap", _ngaylap));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhoahoc", _khoahoc));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("plophoc", _lophoc));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pthu", _thu.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhachhang", _khachhang));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pthanhtoan", _thanhtoan));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmahoadon", _mahoadon));
            //this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
