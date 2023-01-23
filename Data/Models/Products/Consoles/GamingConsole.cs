﻿using Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Products
{
    public class GamingConsole : BaseProduct 
    {
        public Storage Storage { get; set; }
        public ConsoleType Type { get; set; }

    }
}
