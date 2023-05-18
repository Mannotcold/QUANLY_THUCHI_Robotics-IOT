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
            command.CommandText = "select NgayLap,KhoaHoc,LopHoc,thu,chi,Nguoi, Cash,SoHoaDon from PHIEU_THU_CHI";
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


        private void thêmMớiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form thuchi = new THU_CHI();
            this.Hide();
            thuchi.ShowDialog();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form log = new Login();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }


        private void ToExcel(DataGridView dataGridView1)
        {
            
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "mannotcold";

                // export header
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                // export content
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save workbook
                workbook.SaveAs("mannotcold");
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Export successful.!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToExcel(dgvPhieuTC);
        }
    }
}
