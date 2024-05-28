using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_TacGia
    {
        private string maTacGia;
        private string tenTacGia;

        public DTO_TacGia(string maTacGia, string tenTacGia)
        {
            this.maTacGia = maTacGia;
            this.tenTacGia = tenTacGia;
        }

        public string MaTacGia { get => maTacGia; set => maTacGia = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }
    }
}
