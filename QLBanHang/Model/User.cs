using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    public class User
    {
        private string maNhanVien;
        private string tenNhanVien;
        private string gioiTinh;
        private string ngayVaoLam;
        private string thamNien;
        private string phongBan;
        private string matKhau;

        public User(string maNhanVien, string tenNhanVien, string gioiTinh, string ngayVaoLam, string thamNien, string phongBan, string matKhau)
        {
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.gioiTinh = gioiTinh;
            this.ngayVaoLam = ngayVaoLam;
            this.thamNien = thamNien;
            this.phongBan = phongBan;
            this.matKhau = matKhau;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string ThamNien { get => thamNien; set => thamNien = value; }
        public string PhongBan { get => phongBan; set => phongBan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }

        public User(DataRow row)
        {
            this.MaNhanVien = row["MaNhanVien"].ToString();
            this.TenNhanVien = row["TenNhanVien"].ToString();
            this.GioiTinh = row["GioiTinh"].ToString();
            this.NgayVaoLam = row["NgayVaoLam"].ToString();
            this.ThamNien = row["ThamNien"].ToString();
            this.PhongBan = row["PhongBan"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
        }
    }
}
