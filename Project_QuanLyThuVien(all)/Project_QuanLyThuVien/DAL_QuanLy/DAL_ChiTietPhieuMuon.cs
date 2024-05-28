using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_ChiTietPhieuMuon : DBConnect
    {
        public DataTable LayDsChiTietPhieuMuon()
        {
            try
            {
                string strSql = "sp_LayDSChiTietPhieuMuon";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public string LayMaSachTheoTen(string tenSach)
        {
            try
            {
                string strSql = "sp_LayMaSachTheoTen";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@tenSach", tenSach)
                };

                DataTable dataTable = Select(CommandType.StoredProcedure, strSql, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    // Assuming the result is in the first row and the "MaSach" column
                    return dataTable.Rows[0]["MaSach"].ToString();
                }
                else
                {
                    // Handle the case when no result is found
                    return null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public List<string> LayDsTenSach()
        {
            try
            {
                string strSql = "sp_cobTenSach";
                List<string> tenSachList = new List<string>();

                using (DataTable dataTable = Select(CommandType.StoredProcedure, strSql))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string tenSach = row["TenSach"].ToString();
                        tenSachList.Add(tenSach);
                    }
                }

                return tenSachList;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
       

        public bool XoaChiTietPhieuMuon(string maCTPM)
        {
            try
            {
                string strSql = "sp_XoaChiTietPhieuMuon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maCTPM", maCTPM),
                };

                int rowsAffected = ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);

                // Trả về true nếu có ít nhất một dòng bị ảnh hưởng (dòng đã được xóa)
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public bool ThemChiTietPhieuMuon(DTO_ChiTietPhieuMuon dto)
        {
            try
            {
                string strSql = "sp_ThemChiTietPhieuMuon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maCTPM", dto.MaCTPM),
                    new SqlParameter("@maPhieuMuon", dto.MaPhieuMuon),
                    new SqlParameter("@maSach", dto.MaSach),
                };

                int rowsAffected = ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);

                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable LayDsChiTietPhieuMuonTheoMaPM(string maPhieuMuon)
        {
            try
            {
                string strSql = "sp_LayDsChiTietPhieuMuonTheoMaPM";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaPM", maPhieuMuon)
                };

                return Select(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemTheoMaPhieuMuon(string maPhieuMuon)
        {
            try
            {
                string strSql = "sp_TimKiemChiTietPhieuMuon";
                SqlParameter parameter = new SqlParameter("@MaPhieuMuon", maPhieuMuon);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemTheoMaSach(string maSach)
        {
            try
            {
                string strSql = "sp_TimKiemChiTietPhieuMuonTheoMaSach";
                SqlParameter parameter = new SqlParameter("@masach", maSach);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int SuaChiTietPhieuMuon(string maCTPM, string maPhieuMuon, string maSach)
        {
            try
            {
                string strSql = "sp_SuaChiTietPhieuMuon";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaCTPM", maCTPM),
            new SqlParameter("@MaPhieuMuon", maPhieuMuon),
            new SqlParameter("@MaSach", maSach)
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int LaySoLuongChiTietPhieuMuon(string maPhieuMuon)
        {
            try
            {
                string strSql = "sp_LaySoLuongChiTietPhieuMuon";
                SqlParameter[] parameters = {
            new SqlParameter("@MaPhieuMuon", maPhieuMuon)
        };

                DataTable dt = Select(CommandType.StoredProcedure, strSql, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Lấy giá trị số lượng từ cột "SoLuong" trong DataTable
                    return Convert.ToInt32(dt.Rows[0]["SoLuong"]);
                }
                else
                {
                    // Trường hợp không có dữ liệu
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }



    }
}
