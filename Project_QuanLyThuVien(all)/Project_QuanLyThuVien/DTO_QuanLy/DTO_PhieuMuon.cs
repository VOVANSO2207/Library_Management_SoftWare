using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_PhieuMuon
    {
        private string maPhieuMuon;
       
        private string maDocGia;
        private int soLuongMuon;
        private DateTime ngayMuon;
        private DateTime hanTraSach;
        private string maNV;

        public DTO_PhieuMuon(string maPhieuMuon, string maDocGia, int soLuongMuon, DateTime ngayMuon, DateTime hanTraSach, string maNV)
        {
            this.maPhieuMuon = maPhieuMuon;
           
            this.maDocGia = maDocGia;
            this.soLuongMuon = soLuongMuon;
            this.ngayMuon = ngayMuon;
            this.hanTraSach = hanTraSach;
            this.maNV = maNV;
        }

        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
       
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public int SoLuongMuon { get => soLuongMuon; set => soLuongMuon = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime HanTraSach { get => hanTraSach; set => hanTraSach = value; }
        public string MaNV { get => maNV; set => maNV = value; }
    }
}
