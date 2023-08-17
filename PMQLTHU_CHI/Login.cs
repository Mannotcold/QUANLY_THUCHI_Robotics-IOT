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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QLTC;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();

        private void Login_Click(object sender, EventArgs e)
        {
            if (taikhoan.Text == "")
            {
                MessageBox.Show("ID không được để trống");
                return;
            }
            if (matkhau.Text == "")
            {
                MessageBox.Show("Pass không được để trống");
                return;
            }
            
           /* string TK = taikhoan.Text;
            string MK = matkhau.Text;
            if (TK == "dhthuong" && MK == "dhthuong123")
            {
                Form quanLy = new MENU();
                this.Hide();
                quanLy.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Đăng nhập không thành công! Vui lòng kiểm tra lại tài khoản, mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
*/

            try
            {
                string username = taikhoan.Text;
                string password = matkhau.Text;

                connection = new SqlConnection(str);
                connection.Open();
                SqlCommand com = new SqlCommand();
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                //com.ExecuteNonQuery();
                //MAPHIEUDP();
                com.CommandType = CommandType.Text;
                com.CommandText = "select * from TaiKhoan WHERE TEN_TK = '" + username + "' AND MATKHAU = '" + password + "'";
                com.Connection = connection;
                //loaddata();
                int kq = com.ExecuteNonQuery();

                SqlDataReader dta = com.ExecuteReader();
                
                
                if (dta.Read() == true)
                {
                        Form quanLy = new MENU();
                        this.Hide();
                        quanLy.ShowDialog();
                        this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công! Vui lòng kiểm tra lại tài khoản, mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phất triển, vui lòng quay lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Fogetpass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phất triển, vui lòng quay lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
   }
