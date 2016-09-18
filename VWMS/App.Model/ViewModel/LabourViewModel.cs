using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class LabourViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }

        public int? Type { get; set; }

        public string Discription { get; set; }
        
        public string UserEmail { get; set; }

        public string Nic { get; set; }
    }
}
