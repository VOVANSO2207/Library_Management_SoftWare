using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChiTietPhieuMuon
    {
        private string maCTPM;
        private string maPhieuMuon;
        private string maSach;

        public DTO_ChiTietPhieuMuon(string maCTPM, string maPhieuMuon, string maSach)
        {
            this.maCTPM = maCTPM;
            this.maPhieuMuon = maPhieuMuon;
            this.maSach = maSach;
        }

        public string MaCTPM { get => maCTPM; set => maCTPM = value; }
        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public string MaSach { get => maSach; set => maSach = value; }
    }
}
