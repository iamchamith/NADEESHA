using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public class ItemModel
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int Category { get; set; }
        public string Discription { get; set; }
        public double PriceIn { get; set; }
        public double PriceOut { get; set; }
        public int Qiantity { get; set; }
        public string Name { get; set; }
        public int ReorderPoint { get; set; }
        public string BinLocation { get; set; }
        public InventoryType InventoryType { get; set; }
        public string UserName { get; set; }
    }

  
}
