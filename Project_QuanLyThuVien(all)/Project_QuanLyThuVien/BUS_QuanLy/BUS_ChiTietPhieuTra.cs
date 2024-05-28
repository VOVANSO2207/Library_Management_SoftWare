using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_ChiTietPhieuTra
    {
        DAL_ChiTietPhieuTra dal;

        public BUS_ChiTietPhieuTra()
        {
            dal = new DAL_ChiTietPhieuTra();
        }
        public DataTable LayDsChiTietPhieuTra()
        {
            return dal.LayDsChiTietPhieuTra();
        }
        public List<string> LayDsPhieuMuon()
        {
            return dal.LayDsMaPhieuMuon();
        }
        public List<string> LayDsTenSach()
        {
            return dal.LayDsTenSach();
        }
        public DataTable TimKiemCTPTTheoMaPT(string mapt)
        {
            return dal.TimKiemCTPTTheoMaPT(mapt);
        }
        public DataTable TimKiemCTPTTheoMaPM(string mapm)
        {
            return dal.TimKiemCTPTTheoMaPM(mapm);
        }
        public bool CapNhatCTPT(DTO_ChiTietPhieuTra ctpt)
        {
            int rowsAffected = dal.CapNhatCTPT(ctpt);
            return rowsAffected > 0;
        }
        public bool XoaCTPT(string mactpt)
        {
            int rowsAffected = dal.XoaCTPT(mactpt);
            return rowsAffected > 0;
        }
        public bool ThemChiTietPhieuTra(DTO_ChiTietPhieuTra dTO_ChiTietPhieuTra)
        {
            return dal.ThemChiTietPhieuTra(dTO_ChiTietPhieuTra);
        }
        public string LayMaSachTheoTen(string tenSach)
        {
            return dal.LayMaSachTheoTen(tenSach);
        }
    }
}
