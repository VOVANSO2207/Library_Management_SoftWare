using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_DocGia
    {
        private string maDocGia;
        private string tenDocGia;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string diaChi;
        private string CCCCD;
        private string email;
        private int soSachMuon;
        private string loaiDocGia;
        public DTO_DocGia(string maDocGia, string tenDocGia, DateTime ngaySinh, string gioiTinh, string diaChi, string cCCCD, string email, int soSachMuon, string loaiDocGia)
        {
            this.maDocGia = maDocGia;
            this.tenDocGia = tenDocGia;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            CCCCD = cCCCD;
            this.email = email;
            this.soSachMuon = soSachMuon;
            this.loaiDocGia = loaiDocGia;
        }

        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public string TenDocGia { get => tenDocGia; set => tenDocGia = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string CCCCD1 { get => CCCCD; set => CCCCD = value; }
        public string Email { get => email; set => email = value; }
        public int SoSachMuon { get => soSachMuon; set => soSachMuon = value; }
        public string LoaiDocGia { get => loaiDocGia; set => loaiDocGia = value; }
    }
}
