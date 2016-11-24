using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class VehicleJobViewModel
    {
        public int ID { get; set; }
        public string VehicleNumber { get; set; }
        public string UserEmail { get; set; }
        public int? IsFinished { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? CloseTime { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? OpenTime { get; set; }
        public double? FinalAmount { get; set; } // labouru amount
    }
}
