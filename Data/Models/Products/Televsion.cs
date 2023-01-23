using Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Products
{
    public class Television : BaseProduct
    {
        public double Inch { get; set; }
        public Resolution Resolution { get; set; }
        public OperationSystem OperationSystem { get; set; }
        public Panel Panel { get; set; }
    }
}
