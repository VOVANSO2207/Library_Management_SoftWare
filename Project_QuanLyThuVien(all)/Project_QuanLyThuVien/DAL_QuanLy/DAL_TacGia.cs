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
    public class DAL_TacGia : DBConnect
    {
        public DataTable LayDsTacGia()
        {
            try
            {
                string strSql = "sp_LayDSTacGia";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;

            }
        }
        public int ThemTacGia(DTO_TacGia dto)
        {
            try
            {
                string strSql = "sp_ThemTacGia";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@matacgia",dto.MaTacGia),
                    new SqlParameter("@tentacgia",dto.TenTacGia)


                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int XoaTacGia(string matg)
        {
            try
            {
                string strSql = "sp_XoaTacGia";
                SqlParameter parameters = new SqlParameter("@matacgia", matg);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int CapNhatTacGia(DTO_TacGia dto)
        {
            try
            {
                string strSql = "sp_CapNhatTacGia";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@matacgia",dto.MaTacGia),
                new SqlParameter("@tentacgia",dto.TenTacGia)
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
           
        }
        public DataTable TimKiemTacGiaTheoMa(string matacgia)
        {
            try
            {
                string strSql = "sp_TimKiemTacGiaTheoMa";
                SqlParameter parameter = new SqlParameter("@matacgia", matacgia);

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

