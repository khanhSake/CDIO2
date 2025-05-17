using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NhaHang.Model
{
    class model_dangNhapcs
    {
        public int model_DN(String tenDangNhap, String matKhau)
        {
            String sqlDN = "select count(*) from TAIKHOAN " +
                "where TenDangNhap ='"+tenDangNhap +"'and "+
                "MatKhau" ='"+matKhau +"'";
            int ketqua =(int)lop
        }
    }
}
