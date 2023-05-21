﻿using System;
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
                ccbkhthu.Items.Add(reader["KhoaHoc"].ToString());
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
                ccblhthu.Items.Add(reader["LOPHOC"].ToString());
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Tạo ma hoa don theo form sẵn
            MaPhieuMax();
            string mahoadonchi = mahoadon.Text + "/" + MaPhieuMx;
            MessageBox.Show(MaPhieuMx);
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
                    com.CommandText = "insert into PHIEU_THU_CHI (NgayLap,KhoaHoc,LopHoc,chi,Nguoi, Cash,SoHoaDon) VALUES ('" + guna2DateTimePicker1.Text + "',N'" + ccbkhoahoc.Text.ToString() + "',N'" + ccblophoc.Text.ToString() + "','" + txtchi.Text + "',N'" + Nguoi.Text + "',N'" + ccbthanhtoan.Text + "','" + mahoadonchi + "')";
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
                catch (Exception exp)
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
        private void themchi_Click(object sender, EventArgs e)
        {
            //Tạo ma hoa don theo form sẵn
            MaPhieuMax();
            string mahoadon = mahdthu.Text + "/" + MaPhieuMx;
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
                    com.CommandText = "insert into PHIEU_THU_CHI (NgayLap,KhoaHoc,LopHoc,thu,Nguoi, Cash,SoHoaDon) VALUES ('" + timethu.Text + "',N'" + ccbkhthu.Text.ToString() + "',N'" + ccblhthu.Text.ToString() + "','" + txtthu.Text + "',N'" + khachhangchi.Text + "',N'" + thanhtoanthu.Text + "','" + mahoadon + "')";
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
                catch (Exception exp)
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
    }
}
