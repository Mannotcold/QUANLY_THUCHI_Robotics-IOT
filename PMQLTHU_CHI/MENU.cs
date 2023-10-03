using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMQLTHU_CHI
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        //Ket noi server sql
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QLTC;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        DataTable table1 = new DataTable();

        //Bien thu
        string _ngaylap, _khoahoc, _lophoc, _thu, _khachhang, _thanhtoan, _mahoadon, _discount;
       

        void loaddata_PhieuThu()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select CONVERT(nvarchar, NgayLap, 101) " +
                "AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, " +
                "Cash AS Thanh_toán,Discount as Giảm_giá,SoHoaDon AS Số_hóa_đơn from PHIEU_THU";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvPhieuThu.DataSource = table;
            dgvPhieuThu.Columns[0].HeaderText = "Ngày lập";
            dgvPhieuThu.Columns[1].HeaderText = "Khóa học";
            dgvPhieuThu.Columns[2].HeaderText = "Lớp học";
            dgvPhieuThu.Columns[3].HeaderText = "Thu";
            dgvPhieuThu.Columns[4].HeaderText = "Khách hàng";
            dgvPhieuThu.Columns[5].HeaderText = "Thanh toán";
            dgvPhieuThu.Columns[6].HeaderText = "Ghi chú";
            dgvPhieuThu.Columns[7].HeaderText = "Mã hóa đơn";

            connection.Close();
        }

        

        private void dgvPhieuThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvPhieuThu.CurrentRow.Index;
           
            // Lấy giá trị ngày tháng năm từ DateTimePicker
            DataGridViewRow selectedRow = dgvPhieuThu.SelectedRows[0];

            // Lấy giá trị ngày tháng từ ô cụ thể trong cột
            DateTime selectedDate = Convert.ToDateTime(selectedRow.Cells[0].Value);

            // Lấy ngày
            int day = selectedDate.Day;

            // Lấy tháng
            int month = selectedDate.Month;

            // Lấy năm
            int year = selectedDate.Year;

            _ngaylap = "Ngày " + day.ToString()+ " Tháng " + month.ToString() + " Năm " + year.ToString();

            string _ngaylapThu = dgvPhieuThu.Rows[i].Cells[0].Value.ToString();
            _khoahoc = dgvPhieuThu.Rows[i].Cells[1].Value.ToString();
            _lophoc = dgvPhieuThu.Rows[i].Cells[2].Value.ToString();
            _thu = dgvPhieuThu.Rows[i].Cells[3].Value.ToString();
            _khachhang = dgvPhieuThu.Rows[i].Cells[4].Value.ToString();
            _thanhtoan = dgvPhieuThu.Rows[i].Cells[5].Value.ToString();
            _discount = dgvPhieuThu.Rows[i].Cells[6].Value.ToString();
            _mahoadon = dgvPhieuThu.Rows[i].Cells[7].Value.ToString();
            

            txtNgayLapThu.Text = _ngaylapThu;
            txtKhoaHocThu.Text = _khoahoc;
            txtLopHocThu.Text = _lophoc;
            txtThu.Text = _thu;
            txtKhachHang.Text = _khachhang;
            txtPTTTThu.Text = _thanhtoan;
            txtGhiChuThu.Text = _discount;
            mahoadon.Text = _mahoadon;

        }

      

        private void btnXoaThu_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa mã hóa đơn: " + mahoadon.Text.ToString() + "", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                try
                {

                    connection = new SqlConnection(str);
                    connection.Open();
                    SqlCommand com = new SqlCommand();
                    //Lấy dữ liệu về từ kết quả câu lệnh trên
                    //ExecuteReader() dùng với select
                    //ExecuteNonquery(); với inserrt update delete
                    //com.ExecuteNonQuery();
                    //MAPHIEUDP();
                    com.CommandType = CommandType.Text;
                    com.CommandText = "delete from PHIEU_THU where SoHoaDon = '" + mahoadon.Text.ToString() + "'";
                    com.Connection = connection;
                    //loaddata_PhieuThu();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    loaddata_PhieuThu();
                    mahoadon.Clear();

                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mahoadon.Clear();

                }
            }
        }

        private void btnsuathu_Click(object sender, EventArgs e)
        {
            


            DialogResult rs = MessageBox.Show("Bạn có muốn cập nhật hay không", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                try
                {

                    connection = new SqlConnection(str);
                    connection.Open();
                    SqlCommand com = new SqlCommand();
                    //Lấy dữ liệu về từ kết quả câu lệnh trên
                    //ExecuteReader() dùng với select
                    //ExecuteNonquery(); với inserrt update delete
                    //com.ExecuteNonQuery();
                    //MAPHIEUDP();
                    com.CommandType = CommandType.Text; 
                    com.CommandText = "Update PHIEU_THU set KhoaHoc = N'" + txtKhoaHocThu.Text.ToString() + "', " +
                        "LopHoc = N'" + txtLopHocThu.Text.ToString() + "', thu = N'" + txtThu.Text + "', " +
                        "Nguoi = N'" + txtKhachHang.Text.ToString() + "', Cash = N'" + txtPTTTThu.Text.ToString() + "', Discount = N'" + txtGhiChuThu.Text.ToString() + "' " +
                        "where SoHoaDon = N'" + mahoadon.Text + "'";
                    com.Connection = connection;
                    //loaddata_PhieuThu();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                loaddata_PhieuThu();

            }
        }

        // Tra cuu thu

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            //DateTime selectedDate = datetimetracuu.Value.Date;
            //DateTime currentDate = DateTime.Today;

            //// tra cuu khi nguoi dùng khong chon ngày
            //if (selectedDate == currentDate)
            //{
            //    if (CheckBoxChi.Checked == true & CheckBoxThu.Checked == true)
            //    {
            //        if (txtTuKhoa.Text == "")
            //        {
            //            loaddata_PhieuThu();
            //        }
            //        else
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select CONVERT(varchar, NgayLap, 101) AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU WHERE Nguoi LIKE '" + Key + "'or KhoaHoc LIKE '" + Key + "' or LopHoc LIKE '" + Key + "'";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //    }

            //    else if (CheckBoxThu.Checked == true)
            //    {
            //        if (txtTuKhoa.Text == "")
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán," +
            //                "Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU " +
            //                "WHERE thu is not null";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //        else
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn " +
            //                "from PHIEU_THU WHERE thu is not null and Nguoi LIKE '" + Key + "' or thu is not null and KhoaHoc LIKE '" + Key + "' or thu is not null and LopHoc LIKE '" + Key + "'";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //    }
            //    else if (CheckBoxChi.Checked == true)
            //    {
            //        if (txtTuKhoa.Text == "")
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn " +
            //                "from PHIEU_THU WHERE chi is not null";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //        else
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU WHERE chi is not null and Nguoi LIKE '" + Key + "' or chi is not null and KhoaHoc LIKE '" + Key + "' or chi is not null and LopHoc LIKE '" + Key + "'";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //    }

            //    else
            //    {
            //        connection = new SqlConnection(str);
            //        connection.Open();
            //        string Key = txtTuKhoa.Text + '%';
            //        command = connection.CreateCommand();
            //        command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU WHERE Nguoi LIKE '" + Key + "'or KhoaHoc LIKE '" + Key + "' or LopHoc LIKE '" + Key + "'";
            //        adapter.SelectCommand = command;
            //        table.Clear();
            //        adapter.Fill(table);
            //        dgvPhieuThu.DataSource = table;
            //    }
            //}

            //// tra cuu khi nguoi dùng chon ngày cua phieu
            //else
            //{
            //    if (CheckBoxChi.Checked == true & CheckBoxThu.Checked == true)
            //    {
            //        if (txtTuKhoa.Text == "")
            //        {
            //            loaddata_PhieuThu();
            //        }
            //        else
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU " +
            //                "WHERE NgayLap =  '" + datetimetracuu.ToString() + "'  and Nguoi LIKE '" + Key + "'or NgayLap =  '" + datetimetracuu.ToString() + "'  and KhoaHoc LIKE '" + Key + "' or NgayLap =  '" + datetimetracuu.ToString() + "'  and LopHoc LIKE '" + Key + "'";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //    }
            //    else if (CheckBoxThu.Checked == true)
            //    {
            //        if (txtTuKhoa.Text == "")
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán," +
            //                "Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU " +
            //                "WHERE NgayLap =  '" + datetimetracuu.ToString() + "'  and thu is not null ";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //        else
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn " +
            //                "from PHIEU_THU_ WHERE NgayLap =  '" + datetimetracuu.ToString() + "'  and thu is not null and Nguoi LIKE '" + Key + "' or NgayLap =  '" + datetimetracuu.ToString() + "'  and thu is not null and KhoaHoc LIKE '" + Key + "' or NgayLap = '" + datetimetracuu.ToString() + "'  and thu is not null and LopHoc LIKE '" + Key + "'";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //    }
            //    else if (CheckBoxChi.Checked == true)
            //    {
            //        if (txtTuKhoa.Text == "")
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn " +
            //                "from PHIEU_THU WHERE NgayLap =  '" + datetimetracuu.ToString() + "'  and chi is not null";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //        else
            //        {
            //            connection = new SqlConnection(str);
            //            connection.Open();
            //            string Key = txtTuKhoa.Text + '%';
            //            command = connection.CreateCommand();
            //            command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU " +
            //                "WHERE NgayLap =  '" + datetimetracuu.ToString() + "'  and chi is not null and Nguoi LIKE '" + Key + "' or NgayLap =  '" + datetimetracuu.ToString() + "'  and chi is not null and KhoaHoc LIKE '" + Key + "' or NgayLap =  '" + datetimetracuu.ToString() + "'  and chi is not null and LopHoc LIKE '" + Key + "'";
            //            adapter.SelectCommand = command;
            //            table.Clear();
            //            adapter.Fill(table);
            //            dgvPhieuThu.DataSource = table;
            //        }
            //    }

            //    else
            //    {
            //        connection = new SqlConnection(str);
            //        connection.Open();
            //        string Key = txtTuKhoa.Text + '%';
            //        command = connection.CreateCommand();
            //        command.CommandText = "select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn from PHIEU_THU " +
            //            "WHERE NgayLap =  '" + datetimetracuu.ToString() + "'  and Nguoi LIKE '" + Key + "'or NgayLap =  '" + datetimetracuu.ToString() + "'  and KhoaHoc LIKE '" + Key + "' or NgayLap =  '" + datetimetracuu.ToString() + "'  and LopHoc LIKE '" + Key + "'";
            //        adapter.SelectCommand = command;
            //        table.Clear();
            //        adapter.Fill(table);
            //        dgvPhieuThu.DataSource = table;
            //    }
            //}

        }

        private void btnInThu_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn in mã hóa đơn: " + mahoadon.Text.ToString() + "", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                try
                {

                    using (Report frmthu = new Report(_ngaylap.ToString(), _khoahoc, _lophoc, _thu, _khachhang, _thanhtoan, _mahoadon, _discount))
                    {
                        frmthu.ShowDialog();
                    };
                    mahoadon.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("In không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mahoadon.Clear();

                }
            }
        }


        private void btnInportExThu_Click(object sender, EventArgs e)
        {
            Form Import = new ImportExcel();
            this.Hide();
            Import.ShowDialog();
            this.Close();
        }

        private void btnExportThu_Click(object sender, EventArgs e)
        {
            ToExcel(dgvPhieuThu);
        }




















        //Phiếu chi

        // bien chi
        string _ngaylapchi, _khoachi, _noidungchi, _chi, _khachhangchi, _thanhtoanchi, _mahoadonchi, _discountchi;
        string _ngaylapchi2;

        

        private void btnImportEx_Click(object sender, EventArgs e)
        {
            Form Import = new ImportExcel();
            this.Hide();
            Import.ShowDialog();
            this.Close();
        }

        

        void loaddata_PhieuChi()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select CONVERT(nvarchar, NgayLap, 101) AS Ngày_lập,KhoaHoc AS Khóa ,NoiDung AS Nội_dung ,FORMAT(chi, '#,##0') AS Chi,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá,SoHoaDon AS Số_hóa_đơn from PHIEU_CHI";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            dgvPhieuChi.DataSource = table1;

            dgvPhieuChi.Columns[0].HeaderText = "Ngày lập";
            dgvPhieuChi.Columns[1].HeaderText = "Khóa";
            dgvPhieuChi.Columns[2].HeaderText = "Nội dung";
            dgvPhieuChi.Columns[3].HeaderText = "Chi";
            dgvPhieuChi.Columns[4].HeaderText = "Người nhận";
            dgvPhieuChi.Columns[5].HeaderText = "Thanh toán";
            dgvPhieuChi.Columns[6].HeaderText = "Ghi chú";
            dgvPhieuChi.Columns[7].HeaderText = "Mã hóa đơn";
            connection.Close();
        }

        

        private void btnExportEx_Click(object sender, EventArgs e)
        {
            ToExcel(dgvPhieuChi);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa mã hóa đơn: " + mahoadonchi.Text.ToString() + "", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                try
                {

                    connection = new SqlConnection(str);
                    connection.Open();
                    SqlCommand com = new SqlCommand();
                    //Lấy dữ liệu về từ kết quả câu lệnh trên
                    //ExecuteReader() dùng với select
                    //ExecuteNonquery(); với inserrt update delete
                    //com.ExecuteNonQuery();
                    //MAPHIEUDP();
                    com.CommandType = CommandType.Text;
                    com.CommandText = "delete from PHIEU_CHI where SoHoaDon = '" + mahoadonchi.Text.ToString() + "'";
                    com.Connection = connection;
                    //loaddata_PhieuThu();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    loaddata_PhieuThu();
                    mahoadon.Clear();

                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mahoadon.Clear();

                }
            }
        }

        private void btnInChi_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn in mã hóa đơn: " + mahoadonchi.Text.ToString() + "", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                try
                {
                    using (ReportChi frmchi = new ReportChi(_ngaylapchi, _khoachi, _noidungchi, _chi, _khachhangchi, _thanhtoanchi, _mahoadonchi, _discountchi))
                    {
                        frmchi.ShowDialog();
                    };
                    mahoadon.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mahoadon.Clear();

                }
            }
        }

        private void dgvPhieuChi_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvPhieuChi.CurrentRow.Index;

            // Lấy giá trị ngày tháng năm từ DateTimePicker
            DataGridViewRow selectedRow = dgvPhieuChi.SelectedRows[0];

            // Lấy giá trị ngày tháng từ ô cụ thể trong cột
            DateTime selectedDate = Convert.ToDateTime(selectedRow.Cells[0].Value);

            // Lấy ngày
            int day = selectedDate.Day;

            // Lấy tháng
            int month = selectedDate.Month;

            // Lấy năm
            int year = selectedDate.Year;

            _ngaylapchi = "Ngày " + day.ToString() + " Tháng " + month.ToString() + " Năm " + year.ToString();

            _ngaylapchi2 = dgvPhieuChi.Rows[i].Cells[0].Value.ToString(); 
            _khoachi = dgvPhieuChi.Rows[i].Cells[1].Value.ToString();
            _noidungchi = dgvPhieuChi.Rows[i].Cells[2].Value.ToString();
            _chi = dgvPhieuChi.Rows[i].Cells[3].Value.ToString();
            _khachhangchi = dgvPhieuChi.Rows[i].Cells[4].Value.ToString();
            _thanhtoanchi = dgvPhieuChi.Rows[i].Cells[5].Value.ToString();
            _discountchi = dgvPhieuChi.Rows[i].Cells[6].Value.ToString();
            _mahoadonchi = dgvPhieuChi.Rows[i].Cells[7].Value.ToString();

            txtNgayLapchi.Text = _ngaylapchi2;
            txtKhoa.Text = _khoachi;
            txtNoiDung.Text = _noidungchi;
            txtChi.Text = _chi;
            txtNguoiNhan.Text = _khachhangchi;
            txtPTTT.Text = _thanhtoanchi;
            txtGhiChu.Text = _discountchi;
            mahoadonchi.Text = _mahoadonchi;
        }
















        private void MENU_Load(object sender, EventArgs e)
        {
            loaddata_PhieuThu();
           loaddata_PhieuChi();
        }

       

        private void thêmMớiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }


        private void ToExcel(DataGridView dataGridView1)
        {
            
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "mannotcold";

                // export header
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                // export content
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save workbook
                workbook.SaveAs("mannotcold");
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Export successful.!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private void ImportExcel_Click(object sender, EventArgs e)
        {
            Form Import = new ImportExcel();
            this.Hide();
            Import.ShowDialog();
            this.Close();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            Form thuchi = new THU_CHI();
            this.Hide();
            thuchi.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form log = new Login();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
             
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
