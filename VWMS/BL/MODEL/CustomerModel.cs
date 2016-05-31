using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public EEnable Enable { get; set; }
        public DateTime RegDate { get; set; }
        public string UserEmail { get; set; }
        public string ContactPerson { get; set; }
        public string URL { get; set; }
    }
}
