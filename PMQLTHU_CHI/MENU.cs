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

        void loaddata()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select NgayLap,KhoaHoc,LopHoc,Nguoi, Cash,SoHoaDon from PHIEU_THU_CHI";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvPhieuTC.DataSource = table;
            connection.Close();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form thuchi = new THU_CHI();
            this.Hide();
            thuchi.ShowDialog();
            this.Close();
        }
    }
}
