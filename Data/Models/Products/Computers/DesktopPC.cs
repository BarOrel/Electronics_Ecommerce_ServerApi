
using Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Products
{
    public class DesktopPC : BaseProduct
    {
        public Procesor CPU { get; set; }
        public GraphicCard GPU { get; set; }
        public Storage Storage { get; set; }
        


    }
}
