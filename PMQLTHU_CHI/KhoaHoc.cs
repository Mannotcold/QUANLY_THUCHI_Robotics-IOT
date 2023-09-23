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

        private void KhoaHoc_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        string khoahocbd;
        private void dgvkh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvkh.CurrentRow.Index;
            txtKhoaHoc.Text = dgvkh.Rows[i].Cells[0].Value.ToString();
            chitietKH.Text = dgvkh.Rows[i].Cells[1].Value.ToString();
            khoahocbd = txtKhoaHoc.Text;

        }


       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
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
                    com.CommandText = "insert into KHOAHOC (khoahoc, ChiTiet) VALUES (N'" + txtKhoaHoc.Text.ToString() + "', N'" + chitietKH.Text.ToString() + "')";
                    com.Connection = connection;
                    //loaddata_PhieuThu();
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
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void CAPNHAT_Click_1(object sender, EventArgs e)
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
                    com.CommandText = "Update KHOAHOC set khoahoc = N'" + txtKhoaHoc.Text.ToString() + "', ChiTiet = N'" + chitietKH.Text.ToString() + "' where khoahoc = N'" + khoahocbd + "'";
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
                    loaddata();

                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void Xoa_Click_1(object sender, EventArgs e)
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
                    com.CommandText = "delete from KHOAHOC where khoahoc = N'" + txtKhoaHoc.Text.ToString() + "'";
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
                    loaddata();

                }
                catch (Exception)
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
                string Key = txtTuKhoa.Text + '%';
                command = connection.CreateCommand();
                command.CommandText = "select * from KhoaHoc WHERE khoahoc LIKE '" + Key + "'";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvkh.DataSource = table;
            }
        }

        private void Quay_lai_Click_1(object sender, EventArgs e)
        {
            // Gọi hàm từ form THU_CHI khác

            this.Close();
        }
    }
}
    
