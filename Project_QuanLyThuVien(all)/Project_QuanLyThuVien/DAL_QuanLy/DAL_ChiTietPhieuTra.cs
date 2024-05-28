using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_ChiTietPhieuTra : DBConnect
    {
        public DataTable LayDsChiTietPhieuTra()
        {
            try
            {
                string strSql = "sp_LayDSChiTietPhieuTra";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;

            }
        }
        public DataTable TimKiemCTPTTheoMaPT(string mapt)
        {
            try
            {
                string strSql = "sp_TimKiemCTPTTheoMaPT";
                SqlParameter parameter = new SqlParameter("@maphieutra", mapt);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }

        }
       
        public List<string> LayDsMaPhieuMuon()
        {
            try
            {
                string strSql = "sp_cobMaPhieuMuon";
                List<string> maPMList = new List<string>();

                using (DataTable dataTable = Select(CommandType.StoredProcedure, strSql))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string maPM = row["MaPhieuMuon"].ToString();
                        maPMList.Add(maPM);
                    }
                }

                return maPMList;
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
        public int CapNhatCTPT(DTO_ChiTietPhieuTra dto)
        {
            try
            {
                string strSql = "sp_CapNhatChiTietPhieuTra";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@mactpt",dto.MaCTPT),
                  new SqlParameter("@maphieutra",dto.MaPhieuTra),
                new SqlParameter("@maphieumuon",dto.MaPhieuPhuon),
                new SqlParameter("@masach",dto.MaSach),
              
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }

        }
        public DataTable TimKiemCTPTTheoMaPM(string mapm)
        {
            try
            {
                string strSql = "sp_TimKiemCTPTTheoMaPM";
                SqlParameter parameter = new SqlParameter("@maphieumuon", mapm);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int XoaCTPT(string mactpt)
        {
            try
            {
                string strSql = "sp_XoaChiTietPhieuTra";
                SqlParameter parameter = new SqlParameter("@mactpt", mactpt);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameter);
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
        public bool ThemChiTietPhieuTra(DTO_ChiTietPhieuTra dto)
        {
            try
            {
                string strSql = "sp_ThemChiTietPhieuTra";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@mactpt", dto.MaCTPT),
                    new SqlParameter("@maphieutra", dto.MaPhieuTra),
                    new SqlParameter("@maphieumuon", dto.MaPhieuPhuon),
                    new SqlParameter("@masach",dto.MaSach)
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

    }
}
