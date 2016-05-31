using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public class VehicleModel
    {
        public string VehicleID { get; set; }
        public BrandsModel Brand { get; set; }
        public BrandModelModel Model { get; set; }
        public string EngineNumber { get; set; }
        public string ChassiNumber { get; set; }
        public string Discription { get; set; }
        public CustomerModel Owner { get; set; }
        public string UserEmail { get; set; }
        public EEnable Enable { get; set; }
        public DateTime RegDate { get; set; }
        public string URL { get; set; }
    }

    public class VehicleTaskModel
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public string UserEmail { get; set; }
        public string Discription { get; set; }
        public EIsFinished IsFinishied { get; set; }
        public VehicleModel Vehicle { get; set; }
        public List<TaskModel> Task { get; set; }
    }
}
