using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class VehicleViewModel
    {
        public string VehicleID { get; set; }
        public int? BrandID { get; set; }
        public int? ModelId { get; set; }
        public string EngineNumber { get; set; }
        public string ChassiNumber { get; set; }
        public string Discription { get; set; }
        public int? OwnerID { get; set; }
        public string UserEmail { get; set; }
        public DateTime? RegDate { get; set; }
        public string Url { get; set; }
    }

    public class VehicleCustomerViewModel {
        public string VehicleID { get; set; }
        public string EngineNumber { get; set; }
        public string ChassiNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNic { get; set; }
    }
}
