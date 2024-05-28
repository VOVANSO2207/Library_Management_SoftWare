using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhanVien
    {
        private string maNV;
        private string hoTenNV;
        private string gioiTinh;
        private string soDienThoai;
        private string caTruc;
        private string chucVu;

        public DTO_NhanVien(string maNV, string hoTenNV, string gioiTinh, string soDienThoai, string caTruc, string chucVu)
        {
            this.MaNV = maNV;
            this.HoTenNV = hoTenNV;
            this.GioiTinh = gioiTinh;
            this.SoDienThoai = soDienThoai;
            this.CaTruc = caTruc;
            this.chucVu = chucVu;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTenNV { get => hoTenNV; set => hoTenNV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string CaTruc { get => caTruc; set => caTruc = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
    }
}
