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
    public class DAL_NhaXuatBan : DBConnect
    {
        public DataTable LayDSNhaXuatBan()
        {
            try
            {
                string strSql = "sp_layDsNhaXuatBan";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int ThemNhaXuatBan(DTO_NhaXuatBan dto)
        {
            try
            {
                string strSql = "sp_ThemNhaXuatBan";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@manhaxuatban", dto.MaNhaXuat),
                    new SqlParameter("@tennhaxuatban", dto.TenNhaXuatBan),
                    new SqlParameter("@diachi", dto.DiaChi),
                    new SqlParameter("@sdt", dto.SoDienThoai)
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int XoaNhaXuatBan(string manxb)
        {
            try
            {
                string strSql = "sp_XoaNhaXuatBan";
                SqlParameter parameter = new SqlParameter("@manhaxuatban", manxb);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int CapNhatNhaXuatBan(DTO_NhaXuatBan dto)
        {
            try
            {
                string strSql = "sp_CapNhatNhaXuatBan";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@manhaxuatban", dto.MaNhaXuat),
                    new SqlParameter("@tennhaxuatban", dto.TenNhaXuatBan),
                    new SqlParameter("@diachi", dto.DiaChi),
                    new SqlParameter("@sdt", dto.SoDienThoai)
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemMaNXB(string manhaxuatban)
        {
            try
            {
                string strSql = "sp_TimKiemMaNXB";
                SqlParameter parameter = new SqlParameter("@manhaxuatban", manhaxuatban);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }


    }
}
