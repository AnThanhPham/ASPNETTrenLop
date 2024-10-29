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

namespace QLBanHang.Forms
{
    public partial class frmChatLieu : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        public frmChatLieu()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Check inputs
            if(txtMaCL.Text.Trim()=="")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu");
                txtMaCL.Focus();
                return;
            }    
            if(txtTenCL.Text.Trim()=="")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu");
                txtTenCL.Focus();
                return;
            }

            //Check ID of MaChatLieu
            DataTable dtCL = dtBase.ReadData("Select * from tblChatLieu where MaChatLieu='"+
                txtMaCL.Text+"'");
            if(dtCL.Rows.Count>0)
            {
                MessageBox.Show("Mã chất liệu này đã có, Mời bạn nhập mã khác");
                txtMaCL.Focus();
                return;
            }    
            
            string sqlInsert = "insert into tblChatLieu values('"+txtMaCL.Text+"',N'"+
                txtTenCL.Text+"')";
            dtBase.ChangeData(sqlInsert);
            LoadData();
            MessageBox.Show("Thêm mới thành công!");
            ResetInputs();

        }

        private void frmChatLieu_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvChatLieu.Columns[0].HeaderText = "Mã Chất liệu";
            dgvChatLieu.Columns[1].HeaderText = "Tên Chất liệu";
            dgvChatLieu.Columns[1].Width = 300;
            dgvChatLieu.BackgroundColor = Color.Green;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }
        void LoadData()
        {
            string sqlSelect = "Select * from tblChatLieu";
            DataTable dataChatLieu = dtBase.ReadData(sqlSelect);
            //Gắn dữ liệu cho DataGridview
            dgvChatLieu.DataSource = dataChatLieu;
        }

        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCL.Text = dgvChatLieu.CurrentRow.Cells[0].Value.ToString();
            txtTenCL.Text = dgvChatLieu.CurrentRow.Cells[1].Value.ToString();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaCL.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaCL.Text.Trim()=="")
            {
                MessageBox.Show("Bạn phải chọn phần tử để xóa");
                return;
            }    
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa chất liệu này không?",
                "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                try
                {
                    dtBase.ChangeData("delete tblChatLieu where MaChatLieu='" + txtMaCL.Text + "'");
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Có nhiều sản phẩm và hóa đơn có ràng buộc với mã chất liệu này, nên bạn không xóa được");
                }
                
            }
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaCL.Enabled = true;
            ResetInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dtBase.ChangeData("update tblChatLieu set TenChatLieu=N'"+txtTenCL.Text+
                "' where MaChatLieu='"+txtMaCL.Text+"'");
            LoadData();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaCL.Enabled = true;
            ResetInputs();
        }
        void ResetInputs()
        {
            txtMaCL.Text = "";
            txtTenCL.Text = "";
        }
    }
}
