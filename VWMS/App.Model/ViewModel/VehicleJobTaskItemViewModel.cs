using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class VehicleJobTaskItemViewModel
    {
        public int ID { get; set; }
        public int? TaskId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string UserEmail { get; set; }
        public DateTime? RegDate { get; set; }
    }
}
