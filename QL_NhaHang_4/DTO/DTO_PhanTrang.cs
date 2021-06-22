using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhanTrang
    {
        public DataTable dt;
        public int rowCount;
        public DTO_PhanTrang(DataTable dt, int rowCount)
        {
            this.dt = dt;
            this.rowCount = rowCount;
        }
    }
}
