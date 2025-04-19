using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebsite.Models
{
    public class Gym  
    {
        public string MoTaChiTiet { get; set; }
        public string Id { get; set; }
        public string TenPhongTap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string GioMoCua { get; set; }
        public string GioDongCua { get; set; }
        public string ImageUrl { get; set; }
        public List<string> TienIch { get; set; }
    }
}

