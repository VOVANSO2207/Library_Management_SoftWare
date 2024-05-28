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
    public class DAL_DocGia : DBConnect
    {

        public DataTable LayDSDocGia()
        {
            try
            {
                string strSql = "sp_LayDSDocGia";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int ThemDocGia(DTO_DocGia dto)
        {
            try
            {
                string strSql = "sp_ThemDocGia";
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@madocgia",dto.MaDocGia),
                  new SqlParameter("@tendocgia",dto.TenDocGia),
                  new SqlParameter("@ngaysinh",dto.NgaySinh),
                  new SqlParameter("@gioitinh",dto.GioiTinh),
                  new SqlParameter("@diachi",dto.DiaChi),
                  new SqlParameter("@cccd",dto.CCCCD1),
                  new SqlParameter("@email",dto.Email),
                  new SqlParameter("@sosachmuon",dto.SoSachMuon),
                  new SqlParameter("@loaidocgia",dto.LoaiDocGia)
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemDocGiaTheoMaDG(string maDG)
        {
            try
            {
                string strSql = "sp_TimKiemDocGiaTheoMaDG";
                SqlParameter parameter = new SqlParameter("@madocgia", maDG);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemDocGiaTheoTenDG(string maDG)
        {
            try
            {
                string strSql = "sp_TimKiemDocGiaTheoTen";
                SqlParameter parameter = new SqlParameter("@tendocgia", maDG);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemDocGiaTheoDiaChi(string diaChi)
        {

            try
            {
                string strSql = "sp_TimKiemDocGiaTheoDiaChi";
                SqlParameter parameter = new SqlParameter("@diachi", diaChi);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public int XoaDocGia(string maDg)
        {
            try
            {
                string strSql = "sp_XoaDocGia";
                SqlParameter parameter = new SqlParameter("@madocgia", maDg);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int CapNhatDocGia(DTO_DocGia dto)
        {
            try
            {
                string strSql = "sp_CapNhatDocGia";
                SqlParameter[] parameters = new SqlParameter[]
                {
                          new SqlParameter("@madocgia",dto.MaDocGia),

                     new SqlParameter("@tendocgia",dto.TenDocGia),
                  new SqlParameter("@ngaysinh",dto.NgaySinh),
                  new SqlParameter("@gioitinh",dto.GioiTinh),
                  new SqlParameter("@diachi",dto.DiaChi),
                  new SqlParameter("@cccd",dto.CCCCD1),
                  new SqlParameter("@email",dto.Email),
                  new SqlParameter("@sosachmuon",dto.SoSachMuon),
                  new SqlParameter("@loaidocgia",dto.LoaiDocGia)
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public string LayTenDocGiaTheoMa(string maDocGia)
        {
            try
            {
                string strSql = "sp_txtTenDocGia";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@madocgia", maDocGia)
                };

                DataTable dt = Select(CommandType.StoredProcedure, strSql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TenDocGia"].ToString();
                }

                return string.Empty; // Return empty string if not found
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }


    }
}
