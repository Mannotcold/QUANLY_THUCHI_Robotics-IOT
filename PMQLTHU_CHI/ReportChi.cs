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
    public partial class ReportChi : Form
    {


        string _ngaylap, _khoahoc, _lophoc, _chi, _khachhang, _thanhtoan, _mahoadon;

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public ReportChi(string ngaylap, string khoahoc, string lophoc, string chi, string khachhang, string thanhtoan, string mahoadon)
        {
            InitializeComponent();
            _ngaylap = ngaylap;
            _khoahoc = khoahoc;
            _lophoc = lophoc;
            _chi = chi;
            _khachhang = khachhang;
            _thanhtoan = thanhtoan;
            _mahoadon = mahoadon;
        }



        private void ReportChi_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PMQLTHU_CHI.ReportPhieuChi.rdlc";
            List<ReportChi> parameters = new List<ReportChi>();

            // Tạo đối tượng tham số và thêm vào danh sách
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pngaylapchi", _ngaylap));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhoahocchi", _khoahoc));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("plophocchi", _lophoc));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pchi", _chi.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhachhangchi", _khachhang));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pthanhtoanchi", _thanhtoan));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmahoadonchi", _mahoadon));
            this.reportViewer1.RefreshReport();
        }
    }
}
