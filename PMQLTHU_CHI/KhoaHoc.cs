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
    public partial class KhoaHoc : Form
    {
        public KhoaHoc()
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
            command.CommandText = "select * from KHOAHOC";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvkh.DataSource = table;
            connection.Close();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void KhoaHoc_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
