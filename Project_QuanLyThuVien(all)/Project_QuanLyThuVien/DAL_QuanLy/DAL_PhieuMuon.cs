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
    public class DAL_PhieuMuon : DBConnect
    {
        public DataTable LayDsPhieuMuon()
        {
            try
            {
                string strSql = "sp_LayDSPhieuMuon";
                return Select(CommandType.StoredProcedure, strSql);
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
        public string LayTenDGTheoMa(string tenSach)
        {
            try
            {
                string strSql = "sp_LayTenDGTheoMa";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@madocgia", tenSach)
                };

                DataTable dataTable = Select(CommandType.StoredProcedure, strSql, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    // Assuming the result is in the first row and the "MaSach" column
                    return dataTable.Rows[0]["TenDocGia"].ToString();
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
        public int LapPhieuMuon(DTO_PhieuMuon dto)
        {
            try
            {
                string strSql = "sp_ThemPhieuMuon";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@maphieumuon", dto.MaPhieuMuon),

            new SqlParameter("@ngaymuon", dto.NgayMuon),
            new SqlParameter("@hantrasach", dto.HanTraSach),
            new SqlParameter("@madocgia", dto.MaDocGia),
            new SqlParameter("@soluongmuon", dto.SoLuongMuon),
            new SqlParameter("@manv", dto.MaNV)
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int CapNhatPhieuMuon(DTO_PhieuMuon dto)
        {
            try
            {
                string strSql = "sp_CapNhatPhieuMuon";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaPhieuMuon", dto.MaPhieuMuon),
            new SqlParameter("@NgayMuon", dto.NgayMuon),
            new SqlParameter("@HanTraSach", dto.HanTraSach),
            new SqlParameter("@MaDocGia", dto.MaDocGia),
            new SqlParameter("@SoLuongMuon", dto.SoLuongMuon),
            new SqlParameter("@MaNV", dto.MaNV)
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
    

        public DataTable TimKiemPhieuMuonTrung(string maphieumuon)
        {
            try
            {
                string strSql = "sp_TimKiemPhieuMuonTrung";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@maphieumuon", maphieumuon)
                };

                return Select(CommandType.StoredProcedure, strSql, parameters);
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
        public int XoaPhieuMuon(string maPhieuMuon)
        {
            try
            {
                string strSql = "sp_XoaPhieuMuon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                     new SqlParameter("@MaPhieuMuon", maPhieuMuon)
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int DemSoLuongPhieuMuon()
        {
            int soLuong = 0;

            try
            {
                con.Open();

                string strSql = "sp_SoLuongPhieuMuon";
                using (SqlCommand command = new SqlCommand(strSql, con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            soLuong = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return soLuong;
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
