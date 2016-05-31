using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public class LaboursModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public ELabourType Type { get; set; }
        public string NIC { get; set; }
        public EEnable Enable { get; set; }
        public string UserEmail { get; set; }
    }
}
