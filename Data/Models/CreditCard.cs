using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int CVV { get; set; }
        public int Year_ExpirationDate { get; set; }
        public int Month_ExpirationDate { get; set; }
       

    }
}
