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
    public class BUS_PhieuMuon
    {
        DAL_PhieuMuon dal;
      
        public BUS_PhieuMuon()
        {
            dal = new DAL_PhieuMuon();
           
        }
        public DataTable LayDsPhieuMuon()
        {
            return dal.LayDsPhieuMuon();
        }
        public bool CapNhatPhieuMuon(DTO_PhieuMuon pm)
        {
            int rowAffected = dal.CapNhatPhieuMuon(pm);
            return rowAffected > 0;
        }
        public List<string> LayDsTenSach()
        {
            return dal.LayDsTenSach();
        }
        public string LayMaSachTheoTen(string tenSach)
        {
            return dal.LayMaSachTheoTen(tenSach);
        }
        public bool LapPhieuMuon(DTO_PhieuMuon pm)
        {
                         // Call the appropriate method from DAL to insert the record into the database
                return dal.LapPhieuMuon(pm) > 0;
          
        }
        public string LayDsTenSach2()
        {
            List<string> tenSachList = dal.LayDsTenSach();

            // You need to decide how to handle multiple book names. 
            // In this example, it returns the first book name if available.
            return tenSachList.Count > 0 ? tenSachList[0] : null;
        }
        public DataTable TimKiemPhieuMuonTrung(string maphieumuon)
        {
            return dal.TimKiemPhieuMuonTrung(maphieumuon);
        }
        public string LayTenDocGiaTheoMa(string madocgia)
        {
            return dal.LayTenDGTheoMa(madocgia);
        }
        public DataTable LayDsChiTietPhieuMuonTheoMaPM(string maPhieuMuon)
        {

            return dal.LayDsChiTietPhieuMuonTheoMaPM(maPhieuMuon);
        }
        public int XoaPhieuMuon(string maPhieuMuon)
        {           
                return dal.XoaPhieuMuon(maPhieuMuon);
        }
        
        public int SoLuongPhieumuon()
        {
            return dal.DemSoLuongPhieuMuon();
        }
        public int LaySoLuongChiTietPhieuMuon(string maPhieuMuon)
        {
            return dal.LaySoLuongChiTietPhieuMuon(maPhieuMuon);
        }
    }
}
