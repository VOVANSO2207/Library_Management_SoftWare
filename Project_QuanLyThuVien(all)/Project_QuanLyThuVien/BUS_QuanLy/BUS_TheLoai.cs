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
    public class BUS_TheLoai
    {
        DAL_TheLoai dal;
        public BUS_TheLoai()
        {
            dal = new DAL_TheLoai();
        }
        public DataTable layDSTheLoai()
        {
            return dal.LayDSTheLoai();
        }
        public bool ThemTheLoai(DTO_TheLoai tl)
        {
            int rowsAffected = dal.ThemTheLoai(tl);
            return rowsAffected > 0;
        }
        public bool XoaTheLoai(string matl)
        {
            int rowsAffected = dal.XoaTheLoai(matl);
            return rowsAffected > 0;
        }
        public bool CapNhatTheLoai(DTO_TheLoai tl)
        {
            int rowsAffected = dal.CapNhatTheLoai(tl);
            return rowsAffected > 0;
        }
        public DataTable TimTheLoai(string tl)
        {
            return dal.TimKiemTheLoai(tl);
        }
    }
}
