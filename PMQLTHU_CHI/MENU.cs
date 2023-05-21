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


        string _ngaylap, _khoahoc, _lophoc, _thu, _chi, _khachhang, _thanhtoan, _mahoadon;
         
        void loaddata()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select NgayLap,KhoaHoc,LopHoc,FORMAT(thu, '#,##0') AS Thu,FORMAT(chi, '#,##0') AS Chi,Nguoi, Cash,SoHoaDon from PHIEU_THU_CHI";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvPhieuTC.DataSource = table;
            connection.Close();
        }


        private void dgvPhieuTC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvPhieuTC.CurrentRow.Index;
           
            // Lấy giá trị ngày tháng năm từ DateTimePicker
            DataGridViewRow selectedRow = dgvPhieuTC.SelectedRows[0];

            // Lấy giá trị ngày tháng từ ô cụ thể trong cột
            DateTime selectedDate = Convert.ToDateTime(selectedRow.Cells[0].Value);

            // Lấy ngày
            int day = selectedDate.Day;

            // Lấy tháng
            int month = selectedDate.Month;

            // Lấy năm
            int year = selectedDate.Year;

            _ngaylap = "Ngày " + day.ToString()+ " Tháng " + month.ToString() + " Năm " + year.ToString();


            _khoahoc = dgvPhieuTC.Rows[i].Cells[1].Value.ToString();
            _lophoc = dgvPhieuTC.Rows[i].Cells[2].Value.ToString();
            _thu = dgvPhieuTC.Rows[i].Cells[3].Value.ToString();
            _chi = dgvPhieuTC.Rows[i].Cells[4].Value.ToString();
            _khachhang = dgvPhieuTC.Rows[i].Cells[5].Value.ToString();
            _thanhtoan = dgvPhieuTC.Rows[i].Cells[6].Value.ToString();
            _mahoadon = dgvPhieuTC.Rows[i].Cells[7].Value.ToString();
            mahoadon.Text = _mahoadon;


        }

        private void Print_Click(object sender, EventArgs e)
        {
            

            DialogResult rs = MessageBox.Show("Bạn có muốn in mã hóa đơn:" + mahoadon.Text.ToString() + "", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                try
                {

                    if (_thu != "")
                    {
                        using (Report frmthu = new Report(_ngaylap, _khoahoc, _lophoc, _thu, _khachhang, _thanhtoan, _mahoadon))
                        {
                            frmthu.ShowDialog();
                        };
                    }
                    else
                    {
                        using (ReportChi frmchi = new ReportChi(_ngaylap, _khoahoc, _lophoc, _chi, _khachhang, _thanhtoan, _mahoadon))
                        {
                            frmchi.ShowDialog();
                        };
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
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
                    com.CommandText = "delete from PHIEU_THU_CHI where SoHoaDon = '" + mahoadon.Text.ToString() + "'";
                    com.Connection = connection;
                    //loaddata();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    loaddata();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            if (txtTuKhoa.Text == "")
            {
                loaddata();
            }
            else
            {
                connection = new SqlConnection(str);
                connection.Open();
                string TenKH = txtTuKhoa.Text + '%';
                command = connection.CreateCommand();
                command.CommandText = "select * from PHIEU_THU_CHI WHERE Nguoi LIKE '" + TenKH + "'";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvPhieuTC.DataSource = table;
            }
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            loaddata();
        }


        private void thêmMớiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form thuchi = new THU_CHI();
            this.Hide();
            thuchi.ShowDialog();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form log = new Login();
            this.Hide();
            log.ShowDialog();
            this.Close();
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

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToExcel(dgvPhieuTC);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
             
        }
    }
}
