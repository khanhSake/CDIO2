using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHangHoa.DAL
{
    internal class DalHangHoa
    {
        public DalHangHoa()
        {
            lopChung = new LopDungChung();
        }
        LopDungChung lopChung;
        public DataTable DalHH()
        {
            String sqlHH = "select * from HANGHOA";
            return lopChung.LoadDL(sqlHH);
        }
        public DataTable DalNhaCC()
        {
            String sqlNhaCC = "select * from NHACUNGCAP";
            return lopChung.LoadDL(sqlNhaCC);
        }
        public void DalThem(String maHH, String ten, DateTime ngaySX, DateTime hanSD,
            float gia, int soLuong, String maNhaCC, DateTime ngayNhap, String tenHinh)
        {
            string ngaySXFormatted = ngaySX.ToString("yyyy-MM-dd");
            string hanSDFormatted = hanSD.ToString("yyyy-MM-dd");
            string ngayNhapFormatted = ngayNhap.ToString("yyyy-MM-dd");

            String sqlThem = "INSERT INTO HANGHOA VALUES ('" + maHH + "', " +
                "N'" + ten + "', " +
                "'" + ngaySXFormatted + "', " +
                "'" + hanSDFormatted + "', " +
                gia + ", " + soLuong + ", '" + maNhaCC + "', " +
                "'" + ngayNhapFormatted + "', " +
                "'" + tenHinh + "')";
            lopChung.Nonquery(sqlThem);
        }
        public void DalSua(String ten, DateTime ngaySX, DateTime hanSD,float gia, 
            int soLuong, String maNhaCC, DateTime ngayNhap, String tenHinh,String maHH)
        {
            string ngaySXFormatted = ngaySX.ToString("yyyy-MM-dd");
            string hanSDFormatted = hanSD.ToString("yyyy-MM-dd");
            string ngayNhapFormatted = ngayNhap.ToString("yyyy-MM-dd");

            String sqlThem = "INSERT INTO HANGHOA VALUES ('" + maHH + "', " +
                "N'" + ten + "', " +
                "'" + ngaySXFormatted + "', " +
                "'" + hanSDFormatted + "', " +
                gia + ", " + soLuong + ", '" + maNhaCC + "', " +
                "'" + ngayNhapFormatted + "', " +
                "'" + tenHinh + "')";
            lopChung.Nonquery(sqlThem);
        }
        public void DalSua(string maHH, string ten, DateTime ngaySX, DateTime hanSD,
                   float gia, int soLuong, string maNhaCC, DateTime ngayNhap, string tenHinh)
        {
            string ngaySXFormatted = ngaySX.ToString("yyyy-MM-dd");
            string hanSDFormatted = hanSD.ToString("yyyy-MM-dd");
            string ngayNhapFormatted = ngayNhap.ToString("yyyy-MM-dd");

            string sqlSua = "UPDATE HANGHOA SET " +
                            "TenHangHoa = N'" + ten + "', " +
                            "NgaySanXuat = '" + ngaySXFormatted + "', " +
                            "HanSuDung = '" + hanSDFormatted + "', " +
                            "GiaBan = " + gia + ", " +
                            "SoLuong = " + soLuong + ", " +
                            "MaNhaCungCap = '" + maNhaCC + "', " +
                            "NgayNhap = '" + ngayNhapFormatted + "', " +
                            "TenHinh = '" + tenHinh + "' " +
                            "WHERE MaHangHoa = '" + maHH + "'";
            lopChung.Nonquery(sqlSua);
        }
        public DataTable DalTim(string tim)
        {
            string sqlTim = "SELECT * FROM HANGHOA " +
                            "WHERE MaHangHoa LIKE '%" + tim + "%' " +
                            "OR TenHangHoa LIKE N'%" + tim + "%'";
            return lopChung.LoadDL(sqlTim);
        }
        public DataTable DalComboNhaCungCap(string maNCC)
        {
            string sqlNCC = "SELECT * FROM HANGHOA " +
                            "WHERE MaNhaCungCap = '" + maNCC + "'";
            return lopChung.LoadDL(sqlNCC);
        }
        public void DalXoa(string maHH)
        {
            string sqlXoa = "DELETE FROM HANGHOA WHERE MaHangHoa = '" + maHH + "'";
            lopChung.Nonquery(sqlXoa);
        }
        public int DalDem()
        {
            string sqlDem = "SELECT COUNT(*) FROM HANGHOA";
            return lopChung.Scalar(sqlDem);
        }
    }
}
