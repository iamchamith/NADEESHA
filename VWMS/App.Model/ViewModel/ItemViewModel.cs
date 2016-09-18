using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public double? PriceIn { get; set; }
        public double? PriceOut { get; set; }
        public int? Quantity { get; set; }
        public int? ReorderLevel { get; set; }
    }
}
