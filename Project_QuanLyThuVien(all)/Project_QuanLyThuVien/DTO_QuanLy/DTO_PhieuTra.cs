using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_PhieuTra
    {
        private string maPhieuTra;
        private string maDocGia;
        private string maPhieuMuon;
        private DateTime ngayTraSach;
        private string maNV;
        private string ghiChu;

        public DTO_PhieuTra(string maPhieuTra, string maDocGia, string maPhieuMuon, DateTime ngayTraSach, string maNV, string ghiChu)
        {
            this.maPhieuTra = maPhieuTra;
            this.maDocGia = maDocGia;
            this.maPhieuMuon = maPhieuMuon;
            this.ngayTraSach = ngayTraSach;
            this.maNV = maNV;
            this.ghiChu = ghiChu;
        }

        public string MaPhieuTra { get => maPhieuTra; set => maPhieuTra = value; }
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public DateTime NgayTraSach { get => ngayTraSach; set => ngayTraSach = value; }
        public string MaNV { get => maNV; set => maNV = value; }

        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
