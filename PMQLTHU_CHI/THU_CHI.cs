using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SqlClient;

namespace PMQLTHU_CHI
{
    public partial class THU_CHI : Form
    {
        public THU_CHI()
        {
            InitializeComponent();
        }


        //Ket noi server sql
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QLTC;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public void loadkhoahoc()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select KhoaHoc from KhoaHoc";
            // Thực thi câu lệnh SQL và đọc dữ liệu từ SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Thêm dữ liệu vào ComboBox
            while (reader.Read())
            {
                comboBoxKHchi.Items.Add(reader["KhoaHoc"].ToString());
                comboBoxKHthu.Items.Add(reader["KhoaHoc"].ToString());
            }
            connection.Close();
        }

        public void loadlophoc()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select LOPHOC from LOPHOC";
            // Thực thi câu lệnh SQL và đọc dữ liệu từ SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Thêm dữ liệu vào ComboBox
            while (reader.Read())
            {
                comboBoxLHchi.Items.Add(reader["LOPHOC"].ToString());
                comboBoxLHthu.Items.Add(reader["LOPHOC"].ToString());
            }
            connection.Close();
        }

        string MaPhieuMx;
        private void MaPhieuMax()
        {
            connection = new SqlConnection(str);
            connection.Open();

          
            string sql = "select MAX(MaPhieu) FROM PHIEU_THU_CHI";

            SqlCommand com = new SqlCommand(sql, connection);
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            SqlDataReader dta = com.ExecuteReader();
            while (dta.Read())
            {
                int max = dta.GetInt32(0);
                MaPhieuMx = max.ToString();

            }
        }

        //Them chi
        private void Thechi_Click(object sender, EventArgs e)
        {
            //Kiểm tra textbox không được bỏ trống

            if (comboBoxKHchi.Text.ToString() == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin khóa hoc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBoxLHchi.Text.ToString() == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin lớp hoc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtchi.Text == "" )
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin chi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Nguoi.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (ccbthanhtoan.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (discountChi.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //ràng buộc textbox chi chỉ được nhập số
            Regex rgx = new Regex("[^0-9]");
            if (rgx.IsMatch(txtchi.Text))
            {
                MessageBox.Show("Chi chỉ được chứa số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthu.Clear();
                return;
            }

            //Tạo ma hoa don theo form sẵn

            MaPhieuMax();
            // Lấy năm
            DateTime selectedDate = guna2DateTimePicker1.Value;
            int year = selectedDate.Year;
            string mahoadonchi = "PC" + "/"  + year + "/" + MaPhieuMx;
            //MessageBox.Show(MaPhieuMx);
            DialogResult rs = MessageBox.Show("Bạn có muốn thêm hay không", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                    com.CommandText = "insert into PHIEU_THU_CHI (NgayLap,KhoaHoc,LopHoc,chi,Nguoi, Cash,Discount,SoHoaDon) VALUES ('" + guna2DateTimePicker1.Text + "',N'" + comboBoxKHchi.Text.ToString() + "',N'" + comboBoxLHchi.Text.ToString() + "','" + txtchi.Text + "',N'" + Nguoi.Text + "',N'" + ccbthanhtoan.Text + "',N'" + discountChi.Text + "','" + mahoadonchi + "')";
                    com.Connection = connection;
                    //loaddata();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (Exception )
                {
                    MessageBox.Show("Lưu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void THU_CHI_Load(object sender, EventArgs e)
        {
            loadkhoahoc();
            loadlophoc();
        }

        private void Quay_lai_Click(object sender, EventArgs e)
        {
            
            Form menu = new MENU();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }





        //insert thu
        private void themthu_Click(object sender, EventArgs e)
        {



            // //ràng buộc textbox khong được để trống
            if (comboBoxKHthu.Text.ToString() == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin khóa hoc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBoxLHthu.Text.ToString() == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin lớp hoc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtthu.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (khachhangthu.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin người nộp tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (thanhtoanthu.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (discountThu.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            //ràng buộc textbox thu chỉ được nhập số
            Regex rgx = new Regex("[^0-9]");
            if (rgx.IsMatch(txtthu.Text))
            {
                MessageBox.Show("Thu chỉ được chứa số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthu.Clear();
                return;
            }


            //Tạo ma hoa don theo form sẵn
            MaPhieuMax();
            DateTime selectedDate = timethu.Value;
            int year = selectedDate.Year;
            string mahoadonthu = "PT" + "/" + year + "/" + MaPhieuMx;


            DialogResult rs = MessageBox.Show("Bạn có muốn thêm hay không", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                    com.CommandText = "insert into PHIEU_THU_CHI (NgayLap,KhoaHoc,LopHoc,thu,Nguoi, Cash,Discount,SoHoaDon) VALUES ('" + timethu.Text + "',N'" + comboBoxKHthu.Text.ToString() + "',N'" + comboBoxLHthu.Text.ToString() + "','" + txtthu.Text + "',N'" + khachhangthu.Text + "',N'" + thanhtoanthu.Text + "',N'" + discountThu.Text + "','" + mahoadonthu + "')";
                    com.Connection = connection;
                    //loaddata();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (Exception )
                {
                    MessageBox.Show("Lưu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form khoahoc = new KhoaHoc();

            khoahoc.ShowDialog();
        }

        private void khthubtn_Click(object sender, EventArgs e)
        {
            Form khoahoc = new KhoaHoc();
            khoahoc.ShowDialog();
        }

        private void btnlophoc_Click(object sender, EventArgs e)
        {
            Form lophoc = new LopHoc();

            lophoc.ShowDialog();
        }

        private void lhthubtn_Click(object sender, EventArgs e)
        {
            Form lophoc = new LopHoc();
            
            lophoc.ShowDialog();
        }

        private void ccbkhthu_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void ccbkhthu_MouseEnter(object sender, EventArgs e)
        {
            

        }

        private void ccbkhthu_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxKHthu.Items.Clear();
            loadkhoahoc();

        }

        private void ccblhthu_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxLHthu.Items.Clear();
            loadlophoc();
        }

        private void ccbkhoahoc_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxKHchi.Items.Clear();
            loadkhoahoc();
        }

        private void ccblophoc_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxLHchi.Items.Clear();
            loadlophoc();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void khachhangthu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
