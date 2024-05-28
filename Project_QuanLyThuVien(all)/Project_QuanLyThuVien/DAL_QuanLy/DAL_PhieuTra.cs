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
    public class DAL_PhieuTra : DBConnect
    {
        public DataTable LayDsPhieuTra()
        {
            try
            {
                string strSql = "sp_LayDSPhieuTra";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;

            }
        }

        public int LapPhieuTra(DTO_PhieuTra dto)
        {
            try
            {
                string strSql = "sp_ThemPhieuTra";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maphieutra", dto.MaPhieuTra),
                    new SqlParameter("@madocgia", dto.MaDocGia),
                    new SqlParameter("@maphieumuon", dto.MaPhieuMuon),
                    new SqlParameter("@ngaytrasach", dto.NgayTraSach),
                    new SqlParameter("@manv", dto.MaNV),
                     new SqlParameter("@ghichu", dto.GhiChu),

                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
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
                List<string> tenSachList = new List<string>();

                using (DataTable dataTable = Select(CommandType.StoredProcedure, strSql))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string tenSach = row["MaPhieuMuon"].ToString();
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
        public List<string> LayDsMaNV()
        {
            try
            {
                string strSql = "sp_cobMaNV";
                List<string> maNVList = new List<string>();

                using (DataTable dataTable = Select(CommandType.StoredProcedure, strSql))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string maNV = row["MaNV"].ToString();
                        maNVList.Add(maNV);
                    }
                }

                return maNVList;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public List<string> LayDsMaDocGia()
        {
            try
            {
                string strSql = "sp_cobDocGia";
                List<string> maDGList = new List<string>();

                using (DataTable dataTable = Select(CommandType.StoredProcedure, strSql))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string maDG = row["MaDocGia"].ToString();
                        maDGList.Add(maDG);
                    }
                }

                return maDGList;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemPhieuTraTheoMaPT(string mapt)
        {
            try
            {
                string strSql = "sp_TimKiemPhieuTraTheoMaPT";
                SqlParameter parameter = new SqlParameter("@maphieutra", mapt);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemPhieuTraTheoMaDG(string madg)
        {
            try
            {
                string strSql = "sp_TimKiemPhieuTraTheoMaDG";
                SqlParameter parameter = new SqlParameter("@madocgia", madg);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int XoaPhieuTra(string mapt)
        {
            try
            {
                string strSql = "sp_XoaPhieuTra";
                SqlParameter parameters = new SqlParameter("@maphieutra", mapt);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

    }
}
