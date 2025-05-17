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
    public partial class frm_TrangChu: Form
    {
        public frm_TrangChu()
        {
            InitializeComponent();
        }

        private void openTrangHangHoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_HangHoa fm = new frm_HangHoa();
            this.SetVisibleCore(false);
            fm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
