using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace PMQLTHU_CHI
{
    public partial class ImportExcel : Form
    {
        public ImportExcel()
        {
            InitializeComponent();
        }

        //Ket noi server sql
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QLTC;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        DataSet ds = new DataSet();

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var frmDialog = new System.Windows.Forms.OpenFileDialog();
            if (frmDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string constr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""", frmDialog.FileName);
                OleDbConnection myConnection = new OleDbConnection(constr);
                myConnection.Open();
                DataTable spreadSheetData = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = "";
                DataTable dt;
                OleDbCommand onlineConnection;
                OleDbDataAdapter theDataAdapter;

                foreach (DataRow dr in spreadSheetData.Rows)
                {
                    sheetName = dr["TABLE_NAME"].ToString();
                    sheetName = sheetName.Replace("'", "");
                    if (sheetName.EndsWith("$"))
                    {
                        onlineConnection = new OleDbCommand("SELECT * FROM [" + sheetName + "]", myConnection);
                        theDataAdapter = new OleDbDataAdapter(onlineConnection);
                        dt = new DataTable();
                        dt.TableName = sheetName;
                        theDataAdapter.Fill(dt);
                        ds.Tables.Add(dt);
                    }
                }
                myConnection.Close();
                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void bntsave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string ngayLap = row.Cells["Ngày_lập"].Value.ToString();
                        string khoaHoc = row.Cells["Khóa_học"].Value.ToString();
                        string lopHoc = row.Cells["Lớp_học"].Value.ToString();
                        string thu = row.Cells["Thu"].Value.ToString();
                        string khachHang = row.Cells["Khách_hàng"].Value.ToString();
                        string thanhToan = row.Cells["Thanh_toán"].Value.ToString();
                        string giamGia = row.Cells["Giảm_giá"].Value.ToString();
                        string soHoaDon = row.Cells["Số_hóa_đơn"].Value.ToString();

                        string query = "INSERT INTO PHIEU_THU (NgayLap,KhoaHoc,LopHoc,Thu, Nguoi, Cash, Discount ,SoHoaDon) " +
                                       "VALUES (@Ngay_lap, @Khoa_hoc, @Lop_hoc, @Thu, @Khach_hang, @Thanh_toan, @Giam_gia, @So_hoa_don)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Ngay_lap", ngayLap);
                            command.Parameters.AddWithValue("@Khoa_hoc", khoaHoc);
                            command.Parameters.AddWithValue("@Lop_hoc", lopHoc);
                            command.Parameters.AddWithValue("@Thu", thu);
                            command.Parameters.AddWithValue("@Khach_hang", khachHang);
                            command.Parameters.AddWithValue("@Thanh_toan", thanhToan);
                            command.Parameters.AddWithValue("@Giam_gia", giamGia);
                            command.Parameters.AddWithValue("@So_hoa_don", soHoaDon);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Dòng dữ liệu đã được thêm thành công.");
                            }
                            else
                            {
                                Console.WriteLine("Không có dòng nào được thêm.");
                            }
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
