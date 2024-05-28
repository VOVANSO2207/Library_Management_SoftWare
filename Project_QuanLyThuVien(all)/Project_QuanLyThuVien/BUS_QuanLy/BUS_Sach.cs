using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using DAL_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_Sach
    {
        DAL_Sach dal;

        public BUS_Sach()
        {
            dal = new DAL_Sach();
        }

        public DataTable layDsSach()
        {
            return dal.LayDsSach();
        }
        public DataTable layDsSachTimKiem()
        {
            return dal.LayDsSachTimKiem();
        }
        public bool ThemSach(DTO_Sach sach)
        {
            int rowsAffected = dal.ThemSach(sach);
            return rowsAffected > 0;
        }


        public bool XoaSach(string masach)
        {
            int rowsAffected = dal.XoaSach(masach);
            return rowsAffected > 0;
        }

        public bool CapNhatSach(DTO_Sach sach)
        {
            int rowsAffected = dal.CapNhatSach(sach);
            return rowsAffected > 0;
        }
        public DataTable TimKiemThongTinSach(string maSach)
        {
            return dal.TimKiemThongTinSach(maSach);
        }
        public DataTable LayDanhSachMaTheLoai()
        {
            try
            {
                return dal.LayDanhSachMaTheLoai();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ hoặc logging nếu cần thiết
                throw ex;
            }
        }
        public DataTable LayDanhSachMaNhaXuatBan()
        {
            try
            {
                return dal.LayDanhSachMaNhaXuatBan();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ hoặc logging nếu cần thiết
                throw ex;
            }
        }
        public DataTable LayDanhSachMaTacGia()
        {
            try
            {
                return dal.LayDanhSachMaTacGia();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ hoặc logging nếu cần thiết
                throw ex;
            }
        }
        public DataTable TimKiemSachTheoMa(string maTG)
        {
            return dal.TimKiemSachTheoMa(maTG);
        }

        public DataTable TimKiemSachTheoTen(string tenSach)
        {
            return dal.TimKiemSachTheoTen(tenSach);
        }
        public DataTable TimKiemSachTheoTheLoai(string theLoai)
        {
            return dal.TimKiemSachTheoTheLoai(theLoai);
        }
        public DataTable TimKiemSachTheoTacGia(string tacGia)
        {
            return dal.TimKiemSachTheoTacGia(tacGia);
        }

    }
}
