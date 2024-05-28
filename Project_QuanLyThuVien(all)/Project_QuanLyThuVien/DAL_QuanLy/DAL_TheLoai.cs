using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL_QuanLy
{
    public class DAL_TheLoai : DBConnect
    {
        public DataTable LayDSTheLoai()
        {
            try
            {
                string strSql = "sp_LayDSTheLoai";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int ThemTheLoai(DTO_TheLoai tl)
        {
            try
            {
                string strSql = "sp_ThemTheLoai";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@matheloai", tl.MaTheLoai),
                    new SqlParameter("@tentheloai", tl.TenTheLoai),
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int XoaTheLoai(string matl)
        {
            try
            {
                string strSql = "sp_XoaTheLoai1";
                SqlParameter parameter = new SqlParameter("@matheloai", matl);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int CapNhatTheLoai(DTO_TheLoai tl)
        {
            try
            {
                string strSql = "sp_CapNhatTheLoai1";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@matheloai", tl.MaTheLoai),
            new SqlParameter("@tentheloai", tl.TenTheLoai),
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        //public int CapNhatTheLoai(DTO_TheLoai tl)
        //{
        //    try
        //    {
        //        string strSql = "sp_CapNhatTheLoai";
        //        SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@matheloai", tl.MaTheLoai),
        //            new SqlParameter("@tentheloai", tl.TenTheLoai),
        //        };
        //        return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //        throw ex;
        //    }
        //}
        public DataTable TimKiemTheLoai(string maTL)
        {
            try
            {
                string strSql = "sp_TimTheLoai";
                SqlParameter parameter = new SqlParameter("@matheloai", maTL);

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
