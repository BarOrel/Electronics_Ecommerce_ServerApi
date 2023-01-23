using Data.Models.Enums;
using Data.Models.Products.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Products.Computers
{
    public class LaptopPC : DesktopPC
    {
        public int MilliampHours { get; set; }
        public Resolution Resolution { get; set; }
        public Panel Panel { get; set; }
        public double Inch { get; set; }
        public OperationSystem OperationSystem { get; set; }

    }
}
