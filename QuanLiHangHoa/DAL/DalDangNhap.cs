using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHangHoa.DAL
{
    internal class DalDangNhap
    {
        public DalDangNhap()
        {
            lopChung = new LopDungChung();
        }
        LopDungChung lopChung;
        public int DalDN(String tenDN, String MK)
        {
            String sqlDN = "select count (*) from TAIKHOAN " +
            "where TenDangNhap = '" + tenDN + "' and MatKhau = '" + MK + "'";
            return lopChung.Scalar(sqlDN);
        }
    }
}
