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
    public partial class ForgotPassForm : Form
    {
        public ForgotPassForm()
        {
            InitializeComponent();
        }


        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QLTC;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuenMK_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                connection = new SqlConnection(str);
                connection.Open();
                SqlCommand com = new SqlCommand();
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                //com.ExecuteNonQuery();
                //MAPHIEUDP();
                com.CommandType = CommandType.Text;
                com.CommandText = "select * from TaiKhoan WHERE TEN_TK = '" + username + "'";
                com.Connection = connection;
                //loaddata();

                //Lấy mk của tài khoan tim kiem
                SqlDataReader dta = com.ExecuteReader();
                

                if (dta.Read() == true)
                {
                    string pass = dta.GetString(1);
                    MessageBox.Show("Mật khẩu của tài khoản " + username + " là : "+ pass, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại! Vui lòng kiểm tra lại tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }
        }
    }
}
