using Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Products
{
    public class Procesor : BaseProduct
    {
        public CpuType CpuType { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }




    }
}
