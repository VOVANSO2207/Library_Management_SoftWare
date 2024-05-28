using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_QuanLy;
namespace DAL_QuanLy
{
    public class DALQuanLyDocGia : DBConnect
    {
        // private string connectionString = @"Data Source=LAPTOP-HOG0SD7K\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";

        public DataTable LayDSNhaXuatBan()
        {
            DataTable dt = new DataTable();
            //  using (SqlConnection con = new SqlConnection(connectionString))
            //   {
            con.Open();
            using (SqlCommand command = new SqlCommand("sp_layDsNhaXuatBan", con))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }
            //     }
            return dt;
        }

        public int ThemNhaXuatBan(string maNXB, string tenNXB, string diaChi, string sdt)
        {
            //      using (SqlConnection con = new SqlConnection(connectionString))
            //     {
            con.Open();
            using (SqlCommand command = new SqlCommand("sp_ThemNhaXuatBan", con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@manhaxuatban", maNXB);
                command.Parameters.AddWithValue("@tennhaxuatban", tenNXB);
                command.Parameters.AddWithValue("@diachi", diaChi);
                command.Parameters.AddWithValue("@sdt", sdt);

                return command.ExecuteNonQuery();
            }
        }
        //    }

        public int XoaNhaXuatBan(string maNXB)
        {
            //      using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            con.Open();
            using (SqlCommand command = new SqlCommand("sp_XoaNhaXuatBan", con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@manhaxuatban", maNXB);

                return command.ExecuteNonQuery();
            }
            //      }
        }

        public int CapNhatNhaXuatBan(string maNXB, string tenNXB, string diaChi, string sdt)
        {
            //        using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("sp_CapNhatNhaXuatBan", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@manhaxuatban", maNXB);
                    command.Parameters.AddWithValue("@tennhaxuatban", tenNXB);
                    command.Parameters.AddWithValue("@diachi", diaChi);
                    command.Parameters.AddWithValue("@sdt", sdt);

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
