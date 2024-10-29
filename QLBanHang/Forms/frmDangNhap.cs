using QLBanHang.Classes;
using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.Forms
{
    public partial class frmDangNhap : Form
    {
        private DataProcesser dataProcesser;
        public static User user;
        public frmDangNhap()
        {
            InitializeComponent();
            this.dataProcesser = new DataProcesser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text;
            string password = tbPassword.Text;
            string sql = "select * from tblNhanVien where MaNhanVien = '" + username
                + "' and MatKhau = '" + password + "'";
            DataTable dt = dataProcesser.ReadData(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
                user = new User(dt.Rows[0]);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}
