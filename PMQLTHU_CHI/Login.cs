using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQLTHU_CHI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
            
            string TK = taikhoan.Text;
            string MK = matkhau.Text;
            if (TK == "quanly" && MK == "12345")
            {
                Form quanLy = new MENU();
                this.Hide();
                quanLy.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Đăng nhập không thành công! Vui lòng kiểm tra lại tài khoản, mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phất triển, vui lòng quay lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
   }
