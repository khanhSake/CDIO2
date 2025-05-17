using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DASHBOARD.Models
{
    public class NhanVienDAL
    {
        private string sqlServerConn =
ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        private string mySqlConn =
        ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> danhSach = new List<NhanVien>();
            using (SqlConnection conn = new SqlConnection(sqlServerConn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HOSONHANVIEN", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSach.Add(new NhanVien
                    {
                        MaNV = Convert.ToInt32(reader["MaNV"]),
                        HoTen = reader["HoTen"].ToString(),
                        NgaySinh = reader["NgaySinh"] as DateTime?,
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        NgayVaoLam = reader["NgayVaoLam"] as DateTime?,
                        DiaChi = reader["DiaChi"].ToString(),
                        PhongBan = reader["PhongBan"].ToString(),
                        ChucVu = reader["ChucVu"].ToString(),
                    });
                }
            }
            return danhSach;
        }
    }
}