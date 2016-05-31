using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public class JobModel
    {
        public int JobID { get; set; }
        public string VehicleNumber { get; set; }
        public EJobType JobType { get; set; }
        public string UserEmail { get; set; }
        public EIsFinished IsFinished { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseDate { get; set; }
        public DateTime CloseTime { get; set; }
        public double FinalAmount { get; set; }
    }

    public class TaskLabour {

        public int ID { get; set; }
        public int TaskID { get; set; }
        public int LabourID { get; set; }
        public string Discription { get; set; }
        public EIsFinished IsFinied { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string UserEmail { get; set; }
    }


    public class Material
    {

        public int ID { get; set; }
        public int Task_ID { get; set; }
        public int Item_ID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }
        public int QuantityDeference { get; set; }

    }


}
