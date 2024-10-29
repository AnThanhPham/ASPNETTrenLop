namespace QLBanHang.Forms
{
    partial class frmKhachHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTenKhach = new System.Windows.Forms.TextBox();
            this.textBoxDiaChi = new System.Windows.Forms.TextBox();
            this.textBoxSoDienThoai = new System.Windows.Forms.TextBox();
            this.dateTimePickerNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.buttonThem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày sinh";
            // 
            // textBoxTenKhach
            // 
            this.textBoxTenKhach.Location = new System.Drawing.Point(157, 54);
            this.textBoxTenKhach.Name = "textBoxTenKhach";
            this.textBoxTenKhach.Size = new System.Drawing.Size(146, 20);
            this.textBoxTenKhach.TabIndex = 4;
            // 
            // textBoxDiaChi
            // 
            this.textBoxDiaChi.Location = new System.Drawing.Point(157, 104);
            this.textBoxDiaChi.Multiline = true;
            this.textBoxDiaChi.Name = "textBoxDiaChi";
            this.textBoxDiaChi.Size = new System.Drawing.Size(162, 73);
            this.textBoxDiaChi.TabIndex = 5;
            // 
            // textBoxSoDienThoai
            // 
            this.textBoxSoDienThoai.Location = new System.Drawing.Point(413, 54);
            this.textBoxSoDienThoai.Name = "textBoxSoDienThoai";
            this.textBoxSoDienThoai.Size = new System.Drawing.Size(146, 20);
            this.textBoxSoDienThoai.TabIndex = 6;
            // 
            // dateTimePickerNgaySinh
            // 
            this.dateTimePickerNgaySinh.Location = new System.Drawing.Point(413, 140);
            this.dateTimePickerNgaySinh.Name = "dateTimePickerNgaySinh";
            this.dateTimePickerNgaySinh.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerNgaySinh.TabIndex = 7;
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(264, 192);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(118, 27);
            this.buttonThem.TabIndex = 8;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 244);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.dateTimePickerNgaySinh);
            this.Controls.Add(this.textBoxSoDienThoai);
            this.Controls.Add(this.textBoxDiaChi);
            this.Controls.Add(this.textBoxTenKhach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTenKhach;
        private System.Windows.Forms.TextBox textBoxDiaChi;
        private System.Windows.Forms.TextBox textBoxSoDienThoai;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaySinh;
        private System.Windows.Forms.Button buttonThem;
    }
}