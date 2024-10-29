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
    public partial class frmSanPham : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        string imageName = "";
        public frmSanPham()
        {
            InitializeComponent();
            //Lấy dữ liệu đổ ra ComboBox Chất liệu
            DataTable dtCL = dtBase.ReadData("Select * from tblChatLieu");
            cboChatLieu.DataSource = dtCL;
            cboChatLieu.DisplayMember = "TenChatLieu";
            cboChatLieu.ValueMember = "MaChatLieu";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        //Load Data
        void LoadData()
        {
            DataTable dtHang = dtBase.ReadData("Select MaHang,TenHang,"+
                "TenChatLieu,SoLuong,DonGiaNhap,DonGiaBan,"+"" +
                "Anh from tblHang inner join tblChatLieu on tblHang.ChatLieu=tblChatLieu.MaChatLieu");
            dgvHang.DataSource=dtHang;
            dgvHang.Columns[0].HeaderText = "Mã hàng";
            dgvHang.Columns[1].HeaderText = "Tên hàng";
            dgvHang.Columns[2].HeaderText = "Chất liệu";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Giá nhập";
            dgvHang.Columns[5].HeaderText = "Giá bán";
            dgvHang.Columns[6].HeaderText = "File Ảnh";
            ResetValue();

        }
        void ResetValue()
        {
            txtMa.Text = "";
            TxtTen.Text = "";
            cboChatLieu.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            piBImage.Image = null;
            txtMa.Enabled = true;
            txtMa.Focus();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] file;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap Images|*.bmp|JPEG Images|*.jpg|All Files|*.*";
            openFile.FilterIndex = 2;
            openFile.InitialDirectory = Application.StartupPath+ "\\Images\\Hang";
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                piBImage.Image = Image.FromFile(openFile.FileName);
                file = openFile.FileName.Split('\\');
                imageName = file[file.Length-1];
                
            }    
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvHang.CurrentRow.Cells[0].Value.ToString();
            TxtTen.Text= dgvHang.CurrentRow.Cells[1].Value.ToString();
            cboChatLieu.Text = "";
            cboChatLieu.SelectedText= dgvHang.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.Text= dgvHang.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaNhap.Text= dgvHang.CurrentRow.Cells[4].Value.ToString();
            txtDonGiaBan.Text= dgvHang.CurrentRow.Cells[5].Value.ToString();
            imageName= dgvHang.CurrentRow.Cells[6].Value.ToString();
            if (imageName != "")
                piBImage.Image = Image.FromFile(Application.StartupPath + "\\Images\\Hang\\"+ imageName);
            //
            txtMa.Enabled = false;
            TxtTen.Enabled = false;
            cboChatLieu.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtSoLuong.Enabled = false;
            button1.Enabled = false;
            //
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = true;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TxtTen.Enabled = true;
            cboChatLieu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            button1.Enabled = true;
            //
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            //
            TxtTen.Enabled = true;
            cboChatLieu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            button1.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();

            //
            //
            TxtTen.Enabled = true;
            cboChatLieu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            button1.Enabled = true;
            //
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled =false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(btnXoa.Enabled==true)
            {
                sql = "delete tblHang where MaHang='" + txtMa.Text + "'";
            }    
            if(btnThem.Enabled==true)
            {
                //
                if(txtMa.Text.Trim()=="")
                {
                    MessageBox.Show("Bạn phải nhập mã");
                    txtMa.Focus();
                    return;
                }
                if (TxtTen.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập tên");
                    TxtTen.Focus();
                    return;
                }
                //.....
                //Kiểm tra trùng mã
                DataTable dtHang = dtBase.ReadData("Select * from tblHang where MaHang='" + txtMa.Text + "'");
                if(dtHang.Rows.Count>0)
                {
                    MessageBox.Show("Mã hàng đã có, bạn hãy nhập mã khác");
                    txtMa.Focus();
                    return;
                }
                sql = "insert into tblHang values('"+txtMa.Text+"',N'"+TxtTen.Text+
                    "','"+cboChatLieu.SelectedValue+"',"+int.Parse(txtSoLuong.Text)+",'"+txtDonGiaNhap.Text+
                    "','"+txtDonGiaBan.Text+"','"+imageName+"')";
            }
            if (btnSua.Enabled == true)
            {
                sql = "update tblHang set TenHang=N'"+TxtTen.Text+
                    "',ChatLieu='"+cboChatLieu.SelectedValue+"',SoLuong="+int.Parse(txtSoLuong.Text)+
                    ",DonGiaNhap='"+txtDonGiaNhap.Text+"',DonGiaBan='"+txtDonGiaBan.Text+
                    "',Anh='"+imageName+"' where MaHang='"+txtMa.Text+"'";
            }
            try
            {
                dtBase.ChangeData(sql);
                LoadData();
                ResetValue();
            }
            catch
            {
                MessageBox.Show("Sản phẩm đang tồn tại trong một hóa đơn nào đó. Bạn không được xóa");
            }
           
        }
    }
}
