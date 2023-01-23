using Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Products.Mobiles
{
    public class MobilePhone : BaseProduct
    {
        public int MilliampHours { get; set; }
        public Resolution Resolution { get; set; }
        public Panel Panel { get; set; }
        public OperationSystem OperationSystem { get; set; }
        public double Inch { get; set; }

    }
}
