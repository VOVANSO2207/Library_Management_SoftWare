using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
// them data va sqlclient 
// vvs 28.11.
namespace DAL_QuanLy
{
    public class DBConnect
    {
        // vvs 002
        protected SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-HOG0SD7K\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
        /// <summary>
        /// Ham thực hiện lệnh SQL 
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(CommandType cmdType, string strSql, params SqlParameter[] parameters)
        {
            try
            {
                con.Open(); // Mở kết nối trước khi thực hiện câu lệnh SQL

                SqlCommand command = con.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close(); // Đảm bảo kết nối được đóng sau khi thực hiện xong
            }
        }
        /// <summary>
        /// Hàm Đọc Dữ Liệu 
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public SqlDataReader GetReader(CommandType cmdType, string strSql)
        {
            try
            {
                con.Open(); // Mở kết nối trước khi thực hiện câu lệnh SQL

                SqlCommand command = con.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                return command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                throw ex;
            }
            // Không có finally ở đây vì SqlDataReader cần kết nối mở để đọc dữ liệu, 
            // nếu kết nối đóng, SqlDataReader cũng sẽ đóng theo.
        }
        /// <summary>
        /// Hàm hiển Thị Danh Sách 
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable Select(CommandType cmdType, string strSql)
        {
            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
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
        }
        public DataTable Select(CommandType cmdType, string strSql, params SqlParameter[] parameters)
        {
            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
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
        }

    }
}
