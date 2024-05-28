using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;
namespace BUS_QuanLy
{   
    public class BUS_NhaXuatBan
    {
        DAL_NhaXuatBan dal;

        public BUS_NhaXuatBan()
        {
            dal = new DAL_NhaXuatBan();
        }

        public DataTable LayDSNhaXuatBan()
        {
            
            return dal.LayDSNhaXuatBan();
        }

        public bool ThemNhaXuatBan(DTO_NhaXuatBan nxb)
        {
            int rowsAffected = dal.ThemNhaXuatBan(nxb);
            return rowsAffected > 0;
        }

        public bool XoaNhaXuatBan(string manxb)
        {
            int rowsAffected = dal.XoaNhaXuatBan(manxb);
            return rowsAffected > 0;
        }

        public bool CapNhatNhaXuatBan(DTO_NhaXuatBan nxb)
        {
            int rowsAffected = dal.CapNhatNhaXuatBan(nxb);
            return rowsAffected > 0;
        }
        public DataTable TimKiemMaNXB(string manhaxuatban)
        {
            return dal.TimKiemMaNXB(manhaxuatban);
        }


    }
}
