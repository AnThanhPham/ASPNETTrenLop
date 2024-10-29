using QLBanHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLBanHang.Forms
{
    public partial class frmHoaDon : Form
    {
        private DataProcesser dataProcesser;
        private DataTable hoaDonTable;
        public frmHoaDon()
        {
            InitializeComponent();
            this.dataProcesser = new DataProcesser();
            LoadComboboxMaHoaDon();
            LoadMaNhanVien();
            LoadMaKhachHang();
            LoadMaHang();
            LoadBtn();
        }

        private void LoadBtn()
        {
            buttonLuu.Enabled = false;
            buttonHuyHoaDon.Enabled = false;
            buttonInHoaDon.Enabled = false;
            buttonThemHoaDon.Enabled = true;
            buttonDong.Enabled = true;
        }

        private void LoadMaHang()
        {
            string sql = "select * from tblHang";
            DataTable dt = dataProcesser.ReadData(sql);
            foreach(DataRow item in dt.Rows)
            {
                comboBoxMaHang.Items.Add(item["MaHang"].ToString());
            }
        }

        private void DisableThongTinChung()
        {
            textBoxMaHoaDon.Enabled = false;
            textBoxTenNhanVien.Enabled = false;
            textBoxTenKhachHang.Enabled = false;
            textBoxDiaChi.Enabled = false;
            textBoxSoDienThoai.Enabled = false;
            textBoxTongTien.Enabled = false;
        }

        private void LoadComboboxMaHoaDon()
        {
            comboBoxMaHoaDonTimKiem.Items.Clear();
            string sql = "select * from tblHDBan where Datediff(DAY, NgayBan,Getdate()) <= 7;";
            DataTable dt = dataProcesser.ReadData(sql);
            foreach (DataRow dr in dt.Rows) {
                comboBoxMaHoaDonTimKiem.Items.Add(dr["MaHDBAN"].ToString());
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReFreshGiaTri();
            string hdb = GenerateHDB();
            textBoxMaHoaDon.Text = hdb;
            textBoxMaHoaDon.Enabled = false;
            dataGridView1.Enabled = true;
            buttonLuu.Enabled = true;
        }

        private string GenerateHDB()
        {
            string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");

            // Lấy số thứ tự hóa đơn tiếp theo trong ngày
            int soThuTu = LaySoThuTuTiepTheo(ngayHienTai);

            // Tạo mã hóa đơn với số thứ tự (0xxx)
            string maHoaDon = $"HDB_{ngayHienTai}{soThuTu:D4}";

            return maHoaDon;
        }

        private int LaySoThuTuTiepTheo(string ngayHienTai)
        {
            int soThuTu = 1;

            string query = "SELECT MaHDBan FROM tblHDBan WHERE MaHDBan LIKE '%" + $"HDB_{ngayHienTai}%" + "' ORDER BY MaHDBan DESC";
            DataTable dataTable = dataProcesser.ReadData(query);

            // Nếu có dữ liệu, lấy số thứ tự cuối cùng và tăng lên 1
            if (dataTable.Rows.Count > 0)
            {
                string lastMaHoaDon = dataTable.Rows[0]["MaHDBan"].ToString();
                string lastSequence = lastMaHoaDon.Substring(12, 4); // Lấy phần 0xxx
                soThuTu = int.Parse(lastSequence) + 1;
            }

            return soThuTu;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ReFreshGiaTri()
        {
            textBoxMaHoaDon.Text = "";
            textBoxTenNhanVien.Text = "";
            textBoxTenKhachHang.Text = "";
            textBoxDiaChi.Text = "";
            textBoxSoDienThoai.Text = "";
            DateTime ngayBan = DateTime.Now;
            dateTimePickerNgayBan.Value = ngayBan;
            comboBoxMaNhanVien.SelectedItem = null;
            comboBoxMaKhachHang.SelectedItem = null;
            textBoxTongTien.Text = "";
            dataGridView1.DataSource = null;
            hoaDonTable.Clear();
            textBoxTenHang.Text = "";
            textBoxDonGia.Text = "";
            comboBoxMaHang.SelectedItem = null;
            textBoxGiamGia.Text = "";
            textBoxSoLuong.Text = "";
            textBoxThanhTien.Text = "0";
            textBoxTongTien.Text = "0";
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string IDHoaDon = comboBoxMaHoaDonTimKiem.SelectedItem != null ? comboBoxMaHoaDonTimKiem.SelectedItem.ToString() : "";
            if(IDHoaDon != null && IDHoaDon != "")
            {
                string sql = " select * from tblHDBan a \r\n  inner join tblNhanVien b\r\n  on a.MaNhanVien = b.MaNhanVien\r\n  inner join tblKhach c\r\n  on a.MaKhach = c.MaKhach\r\n  where a.MaHDBan = '" + IDHoaDon + "'";
                DataTable dt = dataProcesser.ReadData(sql);
                LoadThongTinChung(dt);
                LoadThongTinMatHangByMaHoaDon(IDHoaDon);
                DisableThongTinChung();
                dataGridView1.Enabled = false;
                buttonHuyHoaDon.Enabled = true;
                buttonInHoaDon.Enabled = true;
            }
            else
            {
                ReFreshGiaTri();
                EnabledThongTinChung();
            }
        }

        private void EnabledThongTinChung()
        {
            textBoxSoDienThoai.Enabled = true;
        }

        private void LoadThongTinMatHangByMaHoaDon(string IDHoaDon)
        {
            string sql = "select c.MaHang,c.TenHang,b.SoLuong,c.DonGiaBan,b.GiamGia,b.ThanhTien\r\n  from tblHDBan a\r\n  inner join tblChiTietHDBan b\r\n  on a.MaHDBan = b.MaHDBan\r\n  inner join tblHang c\r\n  on b.MaHang = c.MaHang\r\n  where a.MaHDBan = '" + IDHoaDon + "'";
            DataTable dt = dataProcesser.ReadData(sql);
            dataGridView1.DataSource = dt;
            long sum = 0;
            foreach (DataRow item in dt.Rows)
            {
                sum += long.Parse(item["ThanhTien"].ToString());
            }
            textBoxTongTien.Text = sum.ToString();
        }

        private void LoadThongTinChung(DataTable dt)
        {
            textBoxMaHoaDon.Text = dt.Rows[0]["MaHDBAN"].ToString();
            textBoxTenNhanVien.Text = dt.Rows[0]["TenNhanVien"].ToString();
            textBoxTenKhachHang.Text = dt.Rows[0]["TenKhach"].ToString();
            textBoxDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            textBoxSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
            DateTime ngayBan = Convert.ToDateTime(dt.Rows[0]["NgayBan"]);
            dateTimePickerNgayBan.Value = ngayBan;
            if (comboBoxMaNhanVien.Items.Contains(dt.Rows[0]["MaNhanVien"]))
            {
                comboBoxMaNhanVien.SelectedItem = dt.Rows[0]["MaNhanVien"];
            }
            if (comboBoxMaKhachHang.Items.Contains(dt.Rows[0]["MaKhach"]))
            {
                comboBoxMaKhachHang.SelectedItem = dt.Rows[0]["MaKhach"];
            }
        }
        private void LoadMaKhachHang()
        {
            comboBoxMaKhachHang.Items.Clear();
            string sql = "select * from tblKhach";
            DataTable dt = dataProcesser.ReadData(sql);
            foreach (DataRow row in dt.Rows)
            {
                comboBoxMaKhachHang.Items.Add(row["MaKhach"].ToString());
            }
        }

        private void LoadMaNhanVien()
        {
            string sql = "select * from tblNhanVien";
            DataTable dt = dataProcesser.ReadData(sql);
            foreach (DataRow row in dt.Rows)
            {
                comboBoxMaNhanVien.Items.Add(row["MaNhanVien"].ToString());
            }
        }

        private void textBoxTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMaHoaDonTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMaHoaDonTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchID = comboBoxMaHoaDonTimKiem.Text;
            if(searchID != "" && searchID != null)
            {
                string sql = " select * from tblHDBan a \r\n  inner join tblNhanVien b\r\n  on a.MaNhanVien = b.MaNhanVien\r\n  inner join tblKhach c\r\n  on a.MaKhach = c.MaKhach\r\n  where a.MaHDBan = '" + searchID + "'";
                DataTable dt = dataProcesser.ReadData(sql);
                if (dt.Rows.Count > 0)
                {
                    LoadThongTinChung(dt);
                    LoadThongTinMatHangByMaHoaDon(searchID);
                    DisableThongTinChung();
                    dataGridView1.Enabled = false;
                    buttonHuyHoaDon.Enabled = true;
                    buttonInHoaDon.Enabled = true;
                }
                else{
                    ReFreshGiaTri();
                    EnabledThongTinChung();
                }
            }
        }

        private void textBoxSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string sdt = textBoxSoDienThoai.Text;
            if(sdt.Length == 10)
            {
                string sql = "select * from tblKhach where SoDienThoai = '" + sdt + "'";
                DataTable dt = dataProcesser.ReadData(sql);
                if (dt.Rows.Count > 0)
                {
                    if (comboBoxMaKhachHang.Items.Contains(dt.Rows[0]["MaKhach"]))
                    {
                        comboBoxMaKhachHang.SelectedItem = dt.Rows[0]["MaKhach"];
                    }
                    textBoxTenKhachHang.Text = dt.Rows[0]["TenKhach"].ToString();
                    textBoxDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                }else
                {
                    comboBoxMaKhachHang.SelectedItem = null;
                    textBoxTenKhachHang.Text = "";
                    textBoxDiaChi.Text = "";
                    MessageBox.Show("Khách hàng chưa có trong cơ sở dữ liệu");
                }

            }
        }

        private void buttonThemKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang formKhachHang = new frmKhachHang();
            formKhachHang.ShowDialog();
            LoadMaKhachHang();
        }

        private void comboBoxMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mahang = comboBoxMaHang.Text;
            if(mahang != null && mahang != "")
            {
                string sql = "select * from tblHang where MaHang = N'" + mahang + "'";
                DataTable dt = dataProcesser.ReadData(sql);
                textBoxTenHang.Text = dt.Rows[0]["TenHang"].ToString();
                textBoxDonGia.Text = dt.Rows[0]["DonGiaBan"].ToString();
                textBoxTenHang.Enabled = false;
                textBoxDonGia.Enabled = false;
                textBoxThanhTien.Enabled = false;
                TinhTienCuaMotMatHang();
            }
        }

        private void TinhTienCuaMotMatHang()
        {
            long gia = textBoxDonGia.Text != "" ? long.Parse(textBoxDonGia.Text) : 0;
            long soLuong = (textBoxSoLuong.Text != "" && textBoxSoLuong.Text != null) ? long.Parse(textBoxSoLuong.Text) : 1;
            long giamgia = (textBoxGiamGia.Text != "" && textBoxGiamGia.Text != null) ? long.Parse(textBoxGiamGia.Text) : 0;
            textBoxThanhTien.Text = ((gia * soLuong) - ((gia * soLuong) * giamgia / 100)).ToString();
        }

        private void textBoxSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhTienCuaMotMatHang();
        }

        private void textBoxGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhTienCuaMotMatHang();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string mahoadon = textBoxMaHoaDon.Text;
            DateTime selectedDate = dateTimePickerNgayBan.Value;
            string ngayban = selectedDate.ToString("yyyy-MM-dd");
            if(comboBoxMaNhanVien.SelectedItem != null && comboBoxMaKhachHang.SelectedItem != null)
            {
                string manhanvien = comboBoxMaNhanVien.SelectedItem.ToString();
                string makhachhang = comboBoxMaKhachHang.SelectedItem.ToString();
                long sum = 0;
                string sql = "insert into tblHDBan values('" + mahoadon + "','" + manhanvien + "','" + makhachhang + "','" + ngayban + "','" + sum + "')";
                dataProcesser.ChangeData(sql);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    string maHang = row.Cells[0].Value.ToString();
                    string tenHang = row.Cells[1].Value.ToString();
                    string soLuong = row.Cells[2].Value.ToString();
                    string dongia = row.Cells[3].Value.ToString();
                    string giamgia = row.Cells[4].Value.ToString();
                    string thanhtien = row.Cells[5].Value.ToString();
                    sum += long.Parse(thanhtien);

                    // insert chi tiết hóa đơn
                    string sql2 = "insert into tblChiTietHDBan values('" + mahoadon + "','" + maHang + "'," + soLuong + "," + giamgia + "," + thanhtien + ")";
                    dataProcesser.ChangeData(sql2);

                    // update lại số hàng tồn 
                    string sql4 = "update tblHang set SoLuong = SoLuong - " + soLuong + " where MaHang = " + maHang;
                    dataProcesser.ChangeData(sql4);
                }

                // update hóa đơn
                string sql5 = "update tblHDBan set TongTien = '" + sum + "' where MaHDBan = '" + mahoadon + "'";
                dataProcesser.ChangeData(sql5);
                ReFreshGiaTri();
                LoadBtn();
            }
            else
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên và mã khách hàng");
            }
        }

        private void buttonThemHangVaoBill_Click(object sender, EventArgs e)
        {
            if(textBoxMaHoaDon.Text != "")
            {
                string mahang = comboBoxMaHang.SelectedItem.ToString();
                string tenhang = textBoxTenHang.Text;
                long gia = long.Parse(textBoxDonGia.Text);
                long giamgia = (textBoxGiamGia.Text != "" && textBoxGiamGia.Text != null) ? long.Parse(textBoxGiamGia.Text) : 0;
                long thanhtien = long.Parse(textBoxThanhTien.Text);
                long soLuong = (textBoxSoLuong.Text != "" && textBoxSoLuong.Text != null) ? long.Parse(textBoxSoLuong.Text) : 1;
                string sql3 = "select * from tblHang where MaHang = '" + mahang + "'";
                DataTable dt = dataProcesser.ReadData(sql3);
                long hangTonTrongKho = long.Parse(dt.Rows[0]["SoLuong"].ToString());
                if (hangTonTrongKho < soLuong)
                {
                    MessageBox.Show("Số lượng hàng tồn trong kho của món hàng này chỉ còn " + hangTonTrongKho);
                }
                else
                {
                    hoaDonTable.Rows.Add(mahang, tenhang, soLuong, gia, giamgia, thanhtien);
                    textBoxTongTien.Text = (long.Parse(textBoxTongTien.Text) + thanhtien).ToString();
                    textBoxTongTien.Enabled = false;
                    dataGridView1.DataSource = hoaDonTable;
                }
            }else
            {
                MessageBox.Show("Bạn cần phải ấn vào nút thêm hóa đơn");
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            hoaDonTable = new DataTable();
            hoaDonTable.Columns.Add("Mã hàng", typeof(string));
            hoaDonTable.Columns.Add("Tên hàng", typeof(string));
            hoaDonTable.Columns.Add("Số Lượng", typeof(long));
            hoaDonTable.Columns.Add("Đơn giá", typeof(long));
            hoaDonTable.Columns.Add("Giảm giá", typeof(long));
            hoaDonTable.Columns.Add("Thành tiền", typeof(long));
            dataGridView1.DataSource = hoaDonTable;
        }

        private void comboBoxMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxMaNhanVien.SelectedItem != null)
            {
                string manhanvien = comboBoxMaNhanVien.SelectedItem.ToString();
                string sql = "select * from tblNhanVien where MaNhanVien = '" + manhanvien + "'";
                DataTable dt = dataProcesser.ReadData(sql);
                textBoxTenNhanVien.Text = dt.Rows[0]["TenNhanVien"].ToString();
                textBoxTenNhanVien.Enabled = false;
            }
        }

        private void comboBoxMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxMaKhachHang.SelectedItem != null)
            {
                string makhachhang = comboBoxMaKhachHang.SelectedItem.ToString();
                string sql = "select * from tblKhach where MaKhach = '" + makhachhang + "'";
                DataTable dt = dataProcesser.ReadData(sql);
                textBoxTenKhachHang.Text = dt.Rows[0]["TenKhach"].ToString();
                textBoxTenKhachHang.Enabled = false;
                textBoxDiaChi.Text = dt.Rows[0]["Diachi"].ToString();
                textBoxDiaChi.Enabled = false;
                textBoxSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                textBoxSoDienThoai.Enabled = false;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // e.RowIndex là chỉ số của hàng được nhấp
            {
                // Xác nhận trước khi xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này không?", "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string tmp = "";
                    if(dataGridView1.Rows[e.RowIndex].Cells[5] != null)
                    {
                        tmp = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    }
                    // Xóa hàng khỏi DataGridView
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    textBoxTongTien.Text = (long.Parse(textBoxTongTien.Text) - long.Parse(tmp)).ToString();
                }
            }
        }

        private void buttonHuyHoaDon_Click(object sender, EventArgs e)
        {
            string maHoaDon = textBoxMaHoaDon.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                string maHang = row.Cells[0].Value.ToString();
                string tenHang = row.Cells[1].Value.ToString();
                string soLuong = row.Cells[2].Value.ToString();
                string dongia = row.Cells[3].Value.ToString();
                string giamgia = row.Cells[4].Value.ToString();
                string thanhtien = row.Cells[5].Value.ToString();

                string sql = "update tblHang set SoLuong = SoLuong + " + soLuong + " where MaHang = '" + maHang +"'";
                dataProcesser.ChangeData(sql);
            }
            string sql2 = "delete from tblHDban where MaHDBan = '" + maHoaDon +"'";
            dataProcesser.ChangeData(sql2);
            ReFreshGiaTri();
            LoadComboboxMaHoaDon();
            LoadBtn();
        }

        private void buttonInHoaDon_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1]; //Đưa con trỏ vào ô A1
            exRange.Font.Size = 15;
            exRange.Font.Bold = true;
            exRange.Font.Color = Color.Blue;
            exRange.Value = "SIÊU THỊ MINI";

            Excel.Range dc = (Excel.Range)exSheet.Cells[2, 1];
            dc.Font.Size = 13;
            dc.Font.Color = Color.Blue;
            dc.Value = "Thụy Phương - Hà Nội";

            //In chữ Hòa đơn bán
            exSheet.Range["D4"].Font.Size = 20;//Đưa con trỏ vào ô A[4,3]
            exSheet.Range["D4"].Font.Bold = true;
            exSheet.Range["D4"].Font.Color = Color.Red;
            exSheet.Range["D4"].Value = "HÓA ĐƠN BÁN";

            //iN CÁC thông tin chung
            exSheet.Range["A5:A8"].Font.Size = 12;
            exSheet.Range["A5"].Value = "Mã hóa đơn: " + textBoxMaHoaDon.Text;
            exSheet.Range["A6"].Value = "Khách hàng: " + comboBoxMaKhachHang.SelectedItem.ToString() + "-" + textBoxTenKhachHang.Text;
            exSheet.Range["A7"].Value = "Địa chi: " + textBoxDiaChi.Text; 
            exSheet.Range["A8"].Value = "Điện thoại:" + textBoxSoDienThoai.Text;

            // In dòng tiêu đề
            exSheet.Range["A10:G10"].Font.Size = 12;
            exSheet.Range["A10:G10"].Font.Bold = true;
            exSheet.Range["C10"].ColumnWidth = 25;
            exSheet.Range["A10"].Value = "STT";
            exSheet.Range["B10"].Value = "Mã hàng";
            exSheet.Range["C10"].Value = "Tên hàng";
            exSheet.Range["D10"].Value = "Số lượng";
            exSheet.Range["E10"].Value = "Đơn giá bán";
            exSheet.Range["E10"].ColumnWidth = 25;
            exSheet.Range["F10"].Value = "Giảm giá";
            exSheet.Range["G10"].ColumnWidth = 25;
            exSheet.Range["G10"].Value = "Thành tiền";

            //In danh sách các chi tiết Sp trong hóa đơn
            int dong = 11;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                exSheet.Range["F" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[4].Value.ToString() + "%";
                exSheet.Range["G" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[5].Value.ToString() + " đồng";
            }
            dong = dong + dataGridView1.Rows.Count;
            exSheet.Range["G"+dong.ToString()].Value = textBoxTongTien.Text + " đồng";
            exSheet.Name = "HDBan";
            exBook.Activate();

            // Lưu file
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2002 Workbook|*.xls|Excel Workbook|*.xlsx|All Files|*.*";
            save.FilterIndex = 2;
            if(save.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(save.FileName.ToLower());
            }
            exApp.Quit();
        }
    }
}
