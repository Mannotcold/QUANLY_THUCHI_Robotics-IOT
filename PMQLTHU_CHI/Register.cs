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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QLTC;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void Register_Click(object sender, EventArgs e)
        {
         
            try
            {
                string username = textBox1.Text;
                string password = textBox3.Text;

                connection = new SqlConnection(str);
                connection.Open();
                SqlCommand com = new SqlCommand();
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                //com.ExecuteNonQuery();
                //MAPHIEUDP();
                com.CommandType = CommandType.Text;
                com.CommandText = "insert into TAIKHOAN(TEN_TK,MATKHAU) VALUES ('" + username + "','" + password + "')";
                com.Connection = connection;


                

        
                int kq = com.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thàng công!");
                    
                }
                else
                {
                    MessageBox.Show("Đăng ký không thàng công! Vui lòng xem lại tài khoản/mật khẩu.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form form = new Login();

            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
