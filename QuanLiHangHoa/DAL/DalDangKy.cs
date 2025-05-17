using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHangHoa.DAL
{
    internal class DalDangKy
    {
        public DalDangKy()
        {
            lopChung = new LopDungChung();
        }
        LopDungChung lopChung;

        public bool KiemTraTaiKhoan(string tenTaiKhoan)
        {
            string query = $"SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = '{tenTaiKhoan}'";
            return lopChung.Scalar(query) > 0;
        }


        public void DangKyTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            string query = $"INSERT INTO TAIKHOAN VALUES (N'{tenTaiKhoan}', '{matKhau}')";
            lopChung.Nonquery(query);
        }
    }
}
