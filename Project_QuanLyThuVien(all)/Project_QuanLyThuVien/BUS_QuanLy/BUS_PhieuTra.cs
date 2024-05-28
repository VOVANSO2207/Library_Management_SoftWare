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
    public class BUS_PhieuTra
    {
        DAL_PhieuTra dal;

        public BUS_PhieuTra()
        {
            dal = new DAL_PhieuTra();
        }

        public DataTable LayDsPhieuTra()
        {
            return dal.LayDsPhieuTra();
        }

        public bool LapPhieuTra(DTO_PhieuTra ptr)
        {
            int rowsAffected = dal.LapPhieuTra(ptr);
            return rowsAffected > 0;
        }
        public List<string> LayDsPhieuMuon()
        {
            return dal.LayDsMaPhieuMuon();
        }
        public List<string> LayDSMaNV()
        {
            return dal.LayDsMaNV();
        }
        public List<string> LayDsMaDG()
        {
            return dal.LayDsMaDocGia();
        }
        public DataTable TimKiemPhieuTraTheoMaPT(string mapt)
        {
            return dal.TimKiemPhieuTraTheoMaPT(mapt);
        }
        public DataTable TimKiemPhieuTraTheoMaDG(string madg)
        {
            return dal.TimKiemPhieuTraTheoMaDG(madg);
        }
        public bool XoaPhieuTra(string mapt)
        {
            int rowsAffected = dal.XoaPhieuTra(mapt);
            return rowsAffected > 0;
        }
    }
}
