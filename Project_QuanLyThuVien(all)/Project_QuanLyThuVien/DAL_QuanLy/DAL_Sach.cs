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
    public class DAL_Sach : DBConnect
    {
        public DataTable LayDsSach()
        {
            try
            {
                string strSql = "sp_LayDSSach";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable LayDsSachTimKiem()
        {
            try
            {
                string strSql = "sp_LayDSSachTimKiem";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int ThemSach(DTO_Sach dto)
        {
            try
            {
                string strSql = "sp_ThemSach";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@masach", dto.MaSach),
            new SqlParameter("@tensach", dto.TenSach),
            new SqlParameter("@namxb", dto.NamXB),
            new SqlParameter("@manhaxuatban", dto.MaNhaXuatBan),
            new SqlParameter("@soluong", dto.SoLuong),
            new SqlParameter("@matheloai", dto.MaTheLoai),
            new SqlParameter("@matacgia", dto.MaTacGia),
            // Thêm các tham số mới
          
                };

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }


        public int XoaSach(string masach)
        {
            try
            {
                string strSql = "sp_XoaSach";
                SqlParameter parameter = new SqlParameter("@masach", masach);

                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }

        public int CapNhatSach(DTO_Sach dto)
        {
            try
            {
                string strSql = "sp_CapNhatSach";
                SqlParameter[] parameters = new SqlParameter[]
                {
                     new SqlParameter("@masach", dto.MaSach),
                    new SqlParameter("@tensach", dto.TenSach),
                    new SqlParameter("@namxb", dto.NamXB),
                     new SqlParameter("@manhaxuatban", dto.MaNhaXuatBan),
                    new SqlParameter("@soluong", dto.SoLuong),
                    new SqlParameter("@matheloai", dto.MaTheLoai),
                    new SqlParameter("@matacgia", dto.MaTacGia)
                };
                return ExecuteNonQuery(CommandType.StoredProcedure, strSql, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable TimKiemThongTinSach(string maSach)
        {
            DataTable resultTable = new DataTable();

            try
            {
                string strSql = "sp_TimKiemThongTinSach";
                SqlParameter parameter = new SqlParameter("@maSach", maSach);

                resultTable = Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }

            return resultTable;
        }
        public DataTable LayDanhSachMaTheLoai()
        {
            try
            {
                string strSql = "sp_LayDanhSachMaTheLoai";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable LayDanhSachMaNhaXuatBan()
        {
            try
            {
                string strSql = "sp_LayDsMaNhaXuatBan";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        public DataTable LayDanhSachMaTacGia()
        {
            try
            {
                string strSql = "sp_LayDsMaTacGia";
                return Select(CommandType.StoredProcedure, strSql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        //TÌm kiếm sách theo mã
        public DataTable TimKiemSachTheoMa(string maSach)
        {
            try
            {
                string strSql = "sp_TimSachTheoMa";
                SqlParameter parameter = new SqlParameter("@masach", maSach);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        //TÌm kiếm sách theo tên
        public DataTable TimKiemSachTheoTen(string maSach)
        {
            try
            {
                string strSql = "sp_TimSachTheoTen";
                SqlParameter parameter = new SqlParameter("@tensach", maSach);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        //tìm kiếm sách theo thể loại
        public DataTable TimKiemSachTheoTheLoai(string maSach)
        {
            try
            {
                string strSql = "sp_TimSachTheoTheLoai";
                SqlParameter parameter = new SqlParameter("@tentheloai", maSach);

                return Select(CommandType.StoredProcedure, strSql, parameter);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
        }
        //TÌm kiếm sách theo tác giả
        public DataTable TimKiemSachTheoTacGia(string maSach)
        {
            try
            {
                string strSql = "sp_TimSachTheoTacGia";
                SqlParameter parameter = new SqlParameter("@tentacgia", maSach);

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
    

