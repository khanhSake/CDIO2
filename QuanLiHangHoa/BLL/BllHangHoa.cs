using QuanLiHangHoa.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHangHoa.BLL
{
    internal class BllHangHoa{
        public BllHangHoa(frm_HangHoa fSV){
            dalHH = new DAL.DalHangHoa();
            hh = fSV;
        }
        DAL.DalHangHoa dalHH;
        frm_HangHoa hh;
        public void BllHH(){
            hh.dataGridView1.DataSource = dalHH.DalHH();
        }
        public void BllNhaCC()
        {
            hh.cb_NhaCungCap.DataSource = dalHH.DalNhaCC();
            hh.cb_NhaCungCap.DisplayMember = "TenNhaCungCap";
            hh.cb_NhaCungCap.ValueMember = "MaNhaCungCap";
        }
        public void BllThem()
        {
            // Chuyển đổi DateTime thành chuỗi đúng định dạng "yyyy-MM-dd"
            string ngaySXFormatted = hh.dateTimePicker_NgaySX.Value.ToString("yyyy-MM-dd");
            string hanSDFormatted = hh.dateTimePicker_HanSD.Value.ToString("yyyy-MM-dd");
            string ngayNhapFormatted = hh.dateTimePicker_NgayNhap.Value.ToString("yyyy-MM-dd");

            // Gọi hàm DalThem với ngày tháng đã được format
            dalHH.DalThem(hh.txt_MaHH.Text, hh.txt_TenHH.Text,
                DateTime.Parse(ngaySXFormatted),
                DateTime.Parse(hanSDFormatted),
                float.Parse(hh.txt_GiaBan.Text),
                int.Parse(hh.txt_SoLuong.Text),
                hh.cb_NhaCungCap.SelectedValue.ToString(),
                DateTime.Parse(ngayNhapFormatted),
                hh.txt_HinhHH.Text);
        }
        public void BllSua()
        {
            string ngaySX = hh.dateTimePicker_NgaySX.Value.ToString("yyyy-MM-dd");
            string hanSD = hh.dateTimePicker_HanSD.Value.ToString("yyyy-MM-dd");
            string ngayNhap = hh.dateTimePicker_NgayNhap.Value.ToString("yyyy-MM-dd");

            dalHH.DalSua(hh.txt_MaHH.Text, hh.txt_TenHH.Text,
                DateTime.Parse(ngaySX), DateTime.Parse(hanSD),
                float.Parse(hh.txt_GiaBan.Text),
                int.Parse(hh.txt_SoLuong.Text),
                hh.cb_NhaCungCap.SelectedValue.ToString(),
                DateTime.Parse(ngayNhap),
                hh.txt_HinhHH.Text);
        }
        public void BllTim()
        {
            hh.dataGridView1.DataSource = dalHH.DalTim(hh.txt_Tim.Text);
        }
        public void BllComboNhaCungCap()
        {
            hh.dataGridView1.DataSource = dalHH.DalComboNhaCungCap(hh.cb_NhaCungCap.SelectedValue.ToString());
        }
        public void BllXoa()
        {
            dalHH.DalXoa(hh.txt_MaHH.Text);
        }
        public void BllDem()
        {
            int demHH = dalHH.DalDem();
            hh.txt_Dem.Text = demHH.ToString();
        }

    }
}
