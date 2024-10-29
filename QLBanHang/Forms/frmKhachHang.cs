using QLBanHang.Classes;
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
    public partial class frmKhachHang : Form
    {
        private DataProcesser dataProcesser;
        public frmKhachHang()
        {
            InitializeComponent();
            this.dataProcesser = new DataProcesser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sdt = textBoxSoDienThoai.Text;
            string ten = textBoxTenKhach.Text;
            string diachi = textBoxDiaChi.Text;
            DateTime selectedDate = dateTimePickerNgaySinh.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            string sql = "select * from tblKhach where SoDienThoai = '" + sdt + "'";
            DataTable dt = dataProcesser.ReadData(sql);
            if (dt.Rows.Count > 0) { 
                MessageBox.Show("Đã tồn tại số điện thoại","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                string sql3 = "select max(MaKhach) as 'Makhach' from tblKhach";
                DataTable dt2 = dataProcesser.ReadData(sql3);
                int ID = int.Parse(dt2.Rows[0]["MaKhach"].ToString()) + 1;
                string sql2 = "insert into tblKhach(Makhach,TenKhach,Diachi,SoDienThoai,NgaySinh) values("+ ID + ",N'" + ten + "',N'" + diachi + "','" + sdt + "','" + formattedDate + "')";
                dataProcesser.ChangeData(sql2);
                MessageBox.Show("Thêm khách hàng thành công");
                this.Close();
            }
        }
    }
}
