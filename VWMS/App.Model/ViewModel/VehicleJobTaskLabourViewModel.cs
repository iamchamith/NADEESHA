using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class VehicleJobTaskLabourViewModel
    {
        public int ID { get; set; }
        public int? TaskId { get; set; }
        public int? LabourId { get; set; }
        public string Discription { get; set; }
        public string UserEmail { get; set; }
        public int? IsClosed { get; set; }
        public DateTime? OpenDateTime { get; set; }
        public DateTime? CloseDateTime { get; set; }
    }
}
