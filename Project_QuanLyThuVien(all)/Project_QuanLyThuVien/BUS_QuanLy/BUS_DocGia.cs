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
    public class BUS_DocGia
    {
        DAL_DocGia dal;

        public BUS_DocGia()
        {
            dal = new DAL_DocGia();
        }

        public DataTable LayDsDocGia()
        {
            return dal.LayDSDocGia();
        }
        public bool ThemDocGia(DTO_DocGia dg)
        {
            int rowsAffected = dal.ThemDocGia(dg);
            return rowsAffected > 0;
        }

        public bool XoaDocGia(string madg)
        {
            int rowsAffected = dal.XoaDocGia(madg);
            return rowsAffected > 0;
        }

        public bool CapNhatDocGia(DTO_DocGia dg)
        {
            int rowsAffected = dal.CapNhatDocGia(dg);
            return rowsAffected > 0;
        }
        public DataTable TimKiemDocGiaTheoMaDG(string maDG)
        {
            return dal.TimKiemDocGiaTheoMaDG(maDG);
        }
        public DataTable TimKiemDocGiaTheoTenDG(string tenDG)
        {
            return dal.TimKiemDocGiaTheoTenDG(tenDG);
        }

        public DataTable TimKiemDocGiaTheoDiaChi(string diaChi)
        {
            return dal.TimKiemDocGiaTheoDiaChi(diaChi);
        }


    }
}
