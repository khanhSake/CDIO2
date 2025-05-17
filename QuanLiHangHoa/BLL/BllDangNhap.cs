using QuanLiHangHoa.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHangHoa.BLL
{
    internal class BllDangNhap
    {
        public BllDangNhap(frm_DangNhap fDN)
        {
            dalDN = new DAL.DalDangNhap();
            dn = fDN;
        }
        frm_DangNhap dn;
        DAL.DalDangNhap dalDN;
        public void BllDN()
        {
            int ketQua = dalDN.DalDN(dn.txt_TenDN.Text, dn.txt_MK.Text);
            if (ketQua >= 1)
            {
                frm_TrangChu fm = new frm_TrangChu();
                fm.Show();
            }
            else MessageBox.Show("Sai tên DN hoặc MK");
        }
    }
}
