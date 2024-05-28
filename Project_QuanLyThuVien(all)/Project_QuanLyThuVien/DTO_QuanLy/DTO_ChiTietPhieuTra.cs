using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChiTietPhieuTra
    {
        private string maCTPT;
        private string maPhieuPhuon;
        private string maSach;
        private string maPhieuTra;

        public DTO_ChiTietPhieuTra(string maCTPT, string maPhieuTra, string maPhieuPhuon, string maSach)
        {
            this.maCTPT = maCTPT;
            this.maPhieuPhuon = maPhieuPhuon;
            this.maSach = maSach;
            this.maPhieuTra = maPhieuTra;
        }

        public string MaCTPT { get => maCTPT; set => maCTPT = value; }
        public string MaPhieuPhuon { get => maPhieuPhuon; set => maPhieuPhuon = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public string MaPhieuTra { get => maPhieuTra; set => maPhieuTra = value; }
    }
}
