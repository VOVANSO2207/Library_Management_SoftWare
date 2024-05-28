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
    public class BUS_PhieuPhat
    {
        DAL_PhieuPhat dal;

        public BUS_PhieuPhat()
        {
            dal = new DAL_PhieuPhat();
        }

        public DataTable LayDSPhieuPhat()
        {
            return dal.LayDsPhieuPhat();
        }

        public bool LapPhieuPhat(DTO_PhieuPhat pp)
        {
            int rowsAffected = dal.LapPhieuPhat(pp);
            return rowsAffected > 0;
        }

        public bool XoaPhieuPhat(string mapp)
        {
            int rowsAffected = dal.XoaPhieuPhat(mapp);
            return rowsAffected > 0;
        }

        public bool CapNhatPhieuPhat(DTO_PhieuPhat pp)
        {
            int rowsAffected = dal.CapNhatPhieuPhat(pp);
            return rowsAffected > 0;
        }
        public DataTable TimKiemPP(string mapp)
        {
            return dal.TimKiemPhieuPhat(mapp);
        }
        public List<string> LayDsPhieuMuon()
        {
            return dal.LayDsMaPhieuMuon();
        }
    }
}
