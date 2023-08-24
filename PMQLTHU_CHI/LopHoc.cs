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
    public partial class LopHoc : Form
    {
        public LopHoc()
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
            command.CommandText = "select * from LOPHOC";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvlh.DataSource = table;
            connection.Close();
        }
        private void LopHoc_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        string lophocbd;


        private void dgvkh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvlh.CurrentRow.Index;
            txtLopHoc.Text = dgvlh.Rows[i].Cells[0].Value.ToString();
            chitietLH.Text = dgvlh.Rows[i].Cells[1].Value.ToString();
            lophocbd = txtLopHoc.Text;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
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
                    com.CommandText = "insert into LOPHOC (LOPHOC, ChiTiet) VALUES (N'" + txtLopHoc.Text.ToString() + "', N'" + chitietLH.Text.ToString() + "')";
                    com.Connection = connection;
                    //loaddata();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    loaddata();

                }
                catch (Exception )
                {
                    MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void CAPNHAT_Click(object sender, EventArgs e)
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
                    com.CommandText = "Update LOPHOC set LOPHOC = N'" + txtLopHoc.Text.ToString() + "', ChiTiet = N'" + chitietLH.Text.ToString() + "' where LOPHOC = N'" + lophocbd + "'";
                    com.Connection = connection;
                    //loaddata();
                    int kq = com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    loaddata();

                }
                catch (Exception )
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa hay không", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                    com.CommandText = "delete from LOPHOC where LOPHOC = N'" + txtLopHoc.Text.ToString() + "'";
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
                catch (Exception )
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
        }

        private void Quay_lai_Click(object sender, EventArgs e)
        {
            
            this.Close();
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
                string Key = txtTuKhoa.Text + '%';
                command = connection.CreateCommand();
                command.CommandText = "select * from KhoaHoc WHERE lophoc LIKE '" + Key + "'";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvlh.DataSource = table;
            }
        }
    }
}
