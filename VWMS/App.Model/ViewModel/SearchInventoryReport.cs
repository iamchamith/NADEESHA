﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.ViewModel
{
    public class SearchInventoryReport
    {
        public string Name { get; set; }
        public int Qty { get; set; }
        public DateTime RegDate { get; set; }
        public double PriceIn { get; set; }
    }
}
