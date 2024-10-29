namespace QLBanHang.Forms
{
    partial class frmSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvHang = new System.Windows.Forms.DataGridView();
            this.cboChatLieu = new System.Windows.Forms.ComboBox();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.TxtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.piBImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piBImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(914, 710);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(158, 48);
            this.btnThoat.TabIndex = 40;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(755, 710);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(153, 48);
            this.btnHuy.TabIndex = 39;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(580, 711);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(158, 48);
            this.btnXoa.TabIndex = 38;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(396, 710);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(158, 48);
            this.btnSua.TabIndex = 37;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(206, 709);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(158, 48);
            this.btnLuu.TabIndex = 36;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 710);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(158, 48);
            this.btnThem.TabIndex = 35;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvHang
            // 
            this.dgvHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHang.Location = new System.Drawing.Point(20, 397);
            this.dgvHang.Name = "dgvHang";
            this.dgvHang.RowHeadersWidth = 51;
            this.dgvHang.RowTemplate.Height = 24;
            this.dgvHang.Size = new System.Drawing.Size(1025, 282);
            this.dgvHang.TabIndex = 34;
            this.dgvHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHang_CellClick);
            // 
            // cboChatLieu
            // 
            this.cboChatLieu.FormattingEnabled = true;
            this.cboChatLieu.Location = new System.Drawing.Point(131, 158);
            this.cboChatLieu.Name = "cboChatLieu";
            this.cboChatLieu.Size = new System.Drawing.Size(341, 24);
            this.cboChatLieu.TabIndex = 33;
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Location = new System.Drawing.Point(134, 342);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(339, 22);
            this.txtDonGiaBan.TabIndex = 31;
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(134, 288);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(340, 22);
            this.txtDonGiaNhap.TabIndex = 30;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(133, 221);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(341, 22);
            this.txtSoLuong.TabIndex = 29;
            // 
            // TxtTen
            // 
            this.TxtTen.Location = new System.Drawing.Point(131, 95);
            this.TxtTen.Name = "TxtTen";
            this.TxtTen.Size = new System.Drawing.Size(344, 22);
            this.TxtTen.TabIndex = 28;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(132, 29);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(343, 22);
            this.txtMa.TabIndex = 27;
            // 
            // piBImage
            // 
            this.piBImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.piBImage.Location = new System.Drawing.Point(755, 49);
            this.piBImage.Name = "piBImage";
            this.piBImage.Size = new System.Drawing.Size(268, 287);
            this.piBImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piBImage.TabIndex = 26;
            this.piBImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 38);
            this.button1.TabIndex = 25;
            this.button1.Text = "Ảnh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Đơn giá bán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Đơn giá nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Chất liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tên hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã hàng";
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 794);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHang);
            this.Controls.Add(this.cboChatLieu);
            this.Controls.Add(this.txtDonGiaBan);
            this.Controls.Add(this.txtDonGiaNhap);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.TxtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.piBImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piBImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvHang;
        private System.Windows.Forms.ComboBox cboChatLieu;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox TxtTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.PictureBox piBImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}