using DTO_QuanLy;
using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal;

        public BUS_NhanVien()
        {
            dal = new DAL_NhanVien();
        }

        public DataTable LayDSNhanVien()
        {
            return dal.LayDSNhanVien();
        }
        public bool ThemNhanVien(DTO_NhanVien nv)
        {
            int rowsAffected = dal.ThemNhanVien(nv);
            return rowsAffected > 0;
        }

        public bool XoaNhanVien(string manv)
        {
            int rowsAffected = dal.XoaNhanVien(manv);
            return rowsAffected > 0;
        }

        public bool CapNhatNhanVien(DTO_NhanVien nv)
        {
            int rowsAffected = dal.CapNhatNhanVien(nv);
            return rowsAffected > 0;
        }
    }
}
