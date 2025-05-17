using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHangHoa.DAL
{
    internal class LopDungChung
    {
        String diaChi = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Van Sinh\\source\\repos\\QuanLiHangHoa\\SQL_HangHoa.mdf\";Integrated Security=True";
        SqlConnection conn;
        public LopDungChung()
        {
            conn = new SqlConnection(diaChi);
        }
        public DataTable LoadDL(String sqlDL)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlDL, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Nonquery(String sqlNon)
        {
            SqlCommand comm = new SqlCommand(sqlNon, conn);
            conn.Open();
            int ketQua = comm.ExecuteNonQuery();
            conn.Close();
            if (ketQua >= 1)
            {
                MessageBox.Show("Thành công");
            }
            else MessageBox.Show("Thất bại");
        }
        public int Scalar(String sqlScalar) 
        {
            SqlCommand comm = new SqlCommand(sqlScalar, conn);
            conn.Open();
            int ketQua = (int)comm.ExecuteScalar();
            conn.Close();
            return ketQua;
        }
    }
}
