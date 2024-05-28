using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_PhieuPhat
    {
        private string maPhieuPhat;
        private string maDocGia;
        private int soNgayQuaHan;
        private int soTienPhat;
        private string maNV;
        private string maPhieuMuon;


        public DTO_PhieuPhat(string maPhieuPhat, string maDocGia, int soNgayQuaHan, int soTienPhat, string maNV, string maPhieuMuon)
        {
            this.maPhieuPhat = maPhieuPhat;
            this.maDocGia = maDocGia;
            this.soNgayQuaHan = soNgayQuaHan;
            this.soTienPhat = soTienPhat;
            this.maNV = maNV;
            this.maPhieuMuon = maPhieuMuon;
          
        }

        public string MaPhieuPhat { get => maPhieuPhat; set => maPhieuPhat = value; }
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public int SoNgayQuaHan { get => soNgayQuaHan; set => soNgayQuaHan = value; }
        public int SoTienPhat { get => soTienPhat; set => soTienPhat = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
    
    }
}
