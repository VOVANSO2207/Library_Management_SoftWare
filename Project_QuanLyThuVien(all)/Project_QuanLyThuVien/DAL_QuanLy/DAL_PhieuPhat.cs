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
    public class DAL_PhieuPhat : DBConnect
    {
        public DataTable LayDsPhieuPhat()
        {
            try
            {
                string strSql = "sp_LayDsPhieuPhat";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;

            }
        }
        public int LapPhieuPhat(DTO_PhieuPhat dto)
        {
            try
            {
                string strSql = "sp_ThemPhieuPhat";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maphieuphat",dto.MaPhieuPhat),
                      new SqlParameter("@madocgia",dto.MaDocGia),
                      new SqlParameter("@songayquahan",dto.SoNgayQuaHan),
                      new SqlParameter("@sotienphat",dto.SoTienPhat),
                      new SqlParameter("@manv",dto.MaNV),
                      new SqlParameter("@maphieumuon",dto.MaPhieuMuon),

                 


                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int XoaPhieuPhat(string mapp)
        {
            try
            {
                string strSql = "sp_XoaPhieuPhat";
                SqlParameter parameters = new SqlParameter("@maphieuphat", mapp);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int CapNhatPhieuPhat(DTO_PhieuPhat dto)
        {
            try
            {
                string strSql = "sp_CapNhatPhieuPhat";
                SqlParameter[] parameters = new SqlParameter[]
                {
               new SqlParameter("@maphieuphat",dto.MaPhieuPhat),
                      new SqlParameter("@madocgia",dto.MaDocGia),
                      new SqlParameter("@songayquahan",dto.SoNgayQuaHan),
                      new SqlParameter("@sotienphat",dto.SoTienPhat),
                      new SqlParameter("@manv",dto.MaNV),
                      new SqlParameter("@maphieumuon",dto.MaPhieuMuon),

                    
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }

        }
        public DataTable TimKiemPhieuPhat(string mapp)
        {
            try
            {
                string strSql = "sp_TimKiemPP";
                SqlParameter parameter = new SqlParameter("@maphieuphat", mapp);

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
      
        
    }
}
