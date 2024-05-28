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
    public class BUS_ChiTietPhieuMuon
    {
        DAL_ChiTietPhieuMuon dal;

        public BUS_ChiTietPhieuMuon()
        {
            dal = new DAL_ChiTietPhieuMuon();
        }

        public DataTable LayDsChiTietPhieuMuon()
        {
            return dal.LayDsChiTietPhieuMuon();
        }
        public string LayMaSachTheoTen(string tenSach)
        {
            return dal.LayMaSachTheoTen(tenSach);
        }
        public List<string> LayDsTenSach()
        {
            return dal.LayDsTenSach();
        }
        public bool ThemChiTietPhieuMuon(DTO_ChiTietPhieuMuon dTO_ChiTietPhieuMuon)
        {
            return dal.ThemChiTietPhieuMuon(dTO_ChiTietPhieuMuon);
        }
        public bool XoaChiTietPhieuMuon(string maCTPM)
        {
            try
            {
                return dal.XoaChiTietPhieuMuon(maCTPM);
            }
            catch (Exception ex)
            {
                // Xử lý exception nếu cần
                throw ex;
            }
        }
        public DataTable LayDsChiTietPhieuMuonTheoMaPM(string maPhieuMuon)
        {

            return dal.LayDsChiTietPhieuMuonTheoMaPM(maPhieuMuon);


        }
        public DataTable TimKiemTheoMaPhieuMuon(string maPhieuMuon)
        {
            return dal.TimKiemTheoMaPhieuMuon(maPhieuMuon);
        }
        public DataTable TimKiemTheoMaSach(string maSach)
        {
            return dal.TimKiemTheoMaSach(maSach);
        }
        public bool SuaChiTietPhieuMuon(string maCTPM, string maPhieuMuon, string maSach)
        {
          
                DAL_ChiTietPhieuMuon dalChiTietPhieuMuon = new DAL_ChiTietPhieuMuon(); // Thay thế bằng tên thích hợp
                return dal.SuaChiTietPhieuMuon(maCTPM, maPhieuMuon, maSach) > 0;          
           
        }
        public int LaySoLuongChiTietPhieuMuon(string maPhieuMuon)
        {
            return dal.LaySoLuongChiTietPhieuMuon(maPhieuMuon);
        }


    }
}
