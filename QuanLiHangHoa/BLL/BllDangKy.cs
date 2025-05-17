using QuanLiHangHoa.DAL;
using QuanLiHangHoa.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHangHoa.BLL
{
    internal class BllDangKy
    {
        public BllDangKy()
        {
            dalDK = new DalDangKy();
        }
        DAL.DalDangKy dalDK;
        public bool DangKyTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            if (!dalDK.KiemTraTaiKhoan(tenTaiKhoan))
            {
                dalDK.DangKyTaiKhoan(tenTaiKhoan, matKhau);
                return true;
            }
            return false;
        }
    }
}
