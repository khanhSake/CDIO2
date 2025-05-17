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
    public partial class frm_DangNhap: Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
            bllDN = new BLL.BllDangNhap(this);
        }
        BLL.BllDangNhap bllDN;

        private void btn_DN_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            bllDN.BllDN();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            frm_DangKy fk = new frm_DangKy();
            this.SetVisibleCore(false);
            fk.Show();
        }
    }
}
