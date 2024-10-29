using QLBanHang.Forms;
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

namespace QLBanHang
{
    public partial class FormMain : Form
    {
        private frmDangNhap formDangNhap;
        public FormMain()
        {
            InitializeComponent();
            formDangNhap = new frmDangNhap();
            UpdateMenuVisibility();
        }

        private void UpdateMenuVisibility()
        {
            if (frmDangNhap.user != null) // Kiểm tra nếu đã đăng nhập thành công
            {
                danhMụcToolStripMenuItem.Enabled = true;
                bánHàngToolStripMenuItem.Enabled = true;
                thốngKêToolStripMenuItem.Enabled = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
                đăngXuấtToolStripMenuItem.Enabled = true;
            }
            else
            {
                danhMụcToolStripMenuItem.Enabled = false;
                bánHàngToolStripMenuItem.Enabled = false;
                thốngKêToolStripMenuItem.Enabled = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
                đăngXuấtToolStripMenuItem.Enabled = false;
            }
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            Forms.frmChatLieu chatLieu = new Forms.frmChatLieu();
            chatLieu.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmSanPham frmSp = new Forms.frmSanPham();
            frmSp.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap formDangNhap = new frmDangNhap();
            formDangNhap.ShowDialog();
            UpdateMenuVisibility();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon formHoaDon = new frmHoaDon();
            formHoaDon.ShowDialog();
        }
    }
}
