using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public class BrandModelModel
    {
        public int ID { get; set; }
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public EEnable Enable { get; set; }
    }
}
