using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_NhanVien : DBConnect
    {
        public DataTable LayDSNhanVien()
        {
            try
            {
                string strSql = "sp_LayDSNhanVien";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int ThemNhanVien(DTO_NhanVien nv)
        {
            try
            {
                string strSql = "sp_ThemNhanVien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@manv", nv.MaNV),
                    new SqlParameter("@hotennv", nv.HoTenNV),
                    new SqlParameter("@gioitinh", nv.GioiTinh),
                    new SqlParameter("@sdt", nv.SoDienThoai),
                    new SqlParameter("@catruc",nv.CaTruc),
                    new SqlParameter("@chucvu",nv.ChucVu)
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int XoaNhanVien(string manv)
        {
            try
            {
                string strSql = "sp_XoaNhanVien";
                SqlParameter parameter = new SqlParameter("@manv", manv);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int CapNhatNhanVien(DTO_NhanVien nv)
        {
            try
            {
                string strSql = "sp_CapNhatNhanVien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@manv", nv.MaNV),
                    new SqlParameter("@hotennv", nv.HoTenNV),
                    new SqlParameter("@gioitinh", nv.GioiTinh),
                    new SqlParameter("@sdt", nv.SoDienThoai),
                    new SqlParameter("@catruc",nv.CaTruc),
                    new SqlParameter("@chucvu",nv.ChucVu)
                };
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
