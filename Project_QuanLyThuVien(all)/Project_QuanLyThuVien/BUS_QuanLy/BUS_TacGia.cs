using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_QuanLy;
using DAL_QuanLy;


namespace BUS_QuanLy
{
    public class BUS_TacGia
    {
        DAL_TacGia dal;

        public BUS_TacGia()
        {
            dal = new DAL_TacGia();
        }
        public DataTable LayDsTacGia()
        {
            return dal.LayDsTacGia();
        }
        public bool ThemTacGia(DTO_TacGia tg)
        {
            int rowAffected = dal.ThemTacGia(tg);
            return rowAffected > 0;
        }

        public bool XoaTacGia(string matg)
        {
            int rowAffected = dal.XoaTacGia(matg);
            return rowAffected > 0;
        }

        public bool CapNhatTacGia(DTO_TacGia tg)
        {
            int rowAffected = dal.CapNhatTacGia(tg);
            return rowAffected > 0;
        }
        public DataTable TimKiemNhaXuatBanTheoMa(string matacgia)
        {
            return dal.TimKiemTacGiaTheoMa(matacgia);
        }
    }


}
