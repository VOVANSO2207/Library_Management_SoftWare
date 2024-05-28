using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhaXuatBan
    {
        private string maNhaXuat;
        private string tenNhaXuatBan;
        private string diaChi;
        private string soDienThoai;

        public DTO_NhaXuatBan(string maNhaXuat, string tenNhaXuatBan, string diaChi, string soDienThoai)
        {
            this.maNhaXuat = maNhaXuat;
            this.tenNhaXuatBan = tenNhaXuatBan;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
        }
        
        public string MaNhaXuat { get => maNhaXuat; set => maNhaXuat = value; }
        public string TenNhaXuatBan { get => tenNhaXuatBan; set => tenNhaXuatBan = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
    }
}
