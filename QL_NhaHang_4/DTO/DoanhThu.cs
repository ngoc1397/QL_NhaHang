using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThu
    {
        private DateTime ngay;
        private double tongTien;

        public DateTime Ngay { get => ngay; set => ngay = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public DoanhThu(DateTime dt, double tongTien)
        {
            this.Ngay = dt;
            this.TongTien = tongTien;
        }
    }
}
