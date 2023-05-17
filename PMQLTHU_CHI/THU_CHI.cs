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


        void loadkhoahoc()
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
                ccbkhoahoc.Items.Add(reader["KhoaHoc"].ToString());
            }
            connection.Close();
        }

        void loadlophoc()
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
                ccblophoc.Items.Add(reader["LOPHOC"].ToString());
            }
            connection.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void THU_CHI_Load(object sender, EventArgs e)
        {
            loadkhoahoc();
            loadlophoc();
        }
    }
}
