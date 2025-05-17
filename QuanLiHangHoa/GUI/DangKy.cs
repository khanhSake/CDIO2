using QuanLiHangHoa.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHangHoa.GUI
{
    public partial class frm_DangKy: Form
    {
        BLL.BllDangKy BllDK;
        public frm_DangKy()
        {
            InitializeComponent();
            BllDK = new BllDangKy();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            String tenTaiKhoan = txt_TenDangNhap.Text;
            String matKhau = txt_MatKhau.Text;
            String nhapLaiMatKhau = txt_NhapLaiMatKhau.Text;

            if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(nhapLaiMatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (matKhau != nhapLaiMatKhau)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            if (BllDK.DangKyTaiKhoan(tenTaiKhoan, matKhau))
            {
                return;
            }
            else
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!");
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            frm_DangNhap frm_DangNhap = new frm_DangNhap();
            this.SetVisibleCore(false);
            frm_DangNhap.Show();
        }
    }
}
