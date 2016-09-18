using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class VehicleJobTaskViewModel
    {
        public int ID { get; set; }
        public int JobId { get; set; }
        public int TaskId { get; set; }
        public string Discription { get; set; }
        public string UserEmail { get; set; }
        public DateTime? Date { get; set; }
        public int? IsClosed { get; set; }
        public double? TaskCost { get; set; }
        public string TaskName { get; set; }
    }
}
