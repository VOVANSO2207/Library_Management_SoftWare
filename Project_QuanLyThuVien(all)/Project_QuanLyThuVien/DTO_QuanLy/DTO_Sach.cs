using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Sach
    {
        private string maSach;
        private string tenSach;
        private int namXB;
        private string maNhaXuatBan;
        private int soLuong;
        private string maTheLoai;
        private string maTacGia;

        public DTO_Sach(string maSach, string tenSach, int namXB, string maNhaXuatBan, int soLuong, string maTheLoai, string maTacGia)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.namXB = namXB;
            this.maNhaXuatBan = maNhaXuatBan;
            this.soLuong = soLuong;
            this.maTheLoai = maTheLoai;
            this.maTacGia = maTacGia;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int NamXB { get => namXB; set => namXB = value; }
        public string MaNhaXuatBan { get => maNhaXuatBan; set => maNhaXuatBan = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string MaTacGia { get => maTacGia; set => maTacGia = value; }
    }
}
