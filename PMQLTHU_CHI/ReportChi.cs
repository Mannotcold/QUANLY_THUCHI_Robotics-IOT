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


        string _ngaylapchi, _khoachi, _noidungchi, _chi, _khachhangchi, _thanhtoanchi, _mahoadonchi, _discountchi;

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public ReportChi(string ngaylap, string khoahoc, string lophoc, string chi, string khachhang, string thanhtoan, string mahoadon, string discount)
        {
            InitializeComponent();
            _ngaylapchi = ngaylap;
            _khoachi = khoahoc;
            _noidungchi = lophoc;
            _chi = chi;
            _khachhangchi = khachhang;
            _thanhtoanchi = thanhtoan;
            _mahoadonchi = mahoadon;
            _discountchi = discount;
        }



        private void ReportChi_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PMQLTHU_CHI.ReportPhieuChi.rdlc";
            List<ReportChi> parameters = new List<ReportChi>();

            // Tạo đối tượng tham số và thêm vào danh sách
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pngaylapchi", _ngaylapchi));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhoahocchi", _khoachi));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("plophocchi", _noidungchi));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pchi", _chi.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhachhangchi", _khachhangchi));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pthanhtoanchi", _thanhtoanchi));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmahoadonchi", _mahoadonchi));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pkhuyenmaichi", _discountchi));
            this.reportViewer1.RefreshReport();
        }
    }
}
