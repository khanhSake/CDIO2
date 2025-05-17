using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DASHBOARD.Models
{
	public class NhanVien
	{
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public string DiaChi { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu { get; set; }

    }
}