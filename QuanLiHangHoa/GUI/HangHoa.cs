using Microsoft.Win32.SafeHandles;
using QuanLiHangHoa.BLL;
using QuanLiHangHoa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHangHoa.GUI
{
    public partial class frm_HangHoa: Form
    {
        public frm_HangHoa()
        {
            InitializeComponent();
            bllHH = new BllHangHoa(this);
        }
        BLL.BllHangHoa bllHH;
        public void loadHH()
        {
            bllHH.BllHH();
        }
        public void loadNhaCC()
        {
            bllHH.BllNhaCC();
        }

        private void frm_HangHoa_Load(object sender, EventArgs e)
        {
            loadNhaCC();
            loadHH();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bllHH.BllThem();
            pb_HinhHH.Image.Save(duongDan + txt_HinhHH.Text);
            loadHH();
        }
        string duongDan = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\HINHANH\\";

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            bllHH.BllSua();
            pb_HinhHH.Image.Save(duongDan + txt_HinhHH.Text);
            loadHH();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            bllHH.BllTim();
        }
        int chon = 0;
        private void cb_NhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chon == 0)
            {
                bllHH.BllComboNhaCungCap();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            bllHH.BllXoa();
            File.Delete(duongDan + txt_TenHH.Text);
            loadHH();
        }

        private void btn_Dem_Click(object sender, EventArgs e)
        {
            bllHH.BllDem();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            loadHH();
        }

        private void pb_HinhHH_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Hãy chọn hình ảnh";
            ofd.Filter = "Tất cả đuôi|*.*|JPG|*.jpg|PNG|*.png|JPEG|*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
                pb_HinhHH.Image = Image.FromFile(ofd.FileName);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaHH.Text = dataGridView1.CurrentRow.Cells["MaHangHoa"].Value.ToString();
            txt_TenHH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker_NgaySX.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker_HanSD.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_GiaBan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_SoLuong.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            chon = 1;
            cb_NhaCungCap.SelectedValue = dataGridView1.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
            chon = 0;
            dateTimePicker_NgayNhap.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_HinhHH.Text = dataGridView1.CurrentRow.Cells["TenHinh"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            frm_TrangChu fm = new frm_TrangChu();
            this.SetVisibleCore(false);
            fm.Show();
        }
    }
}
