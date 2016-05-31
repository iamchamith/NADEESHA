using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BL.MODEL
{
   public class BookingModel
    {

       public int ID { get; set; }
       public string VEHICLE_ID { get; set; }
       public int OWNER_ID { get; set; }
       public string CUS_CONCERN { get; set; }
       public DateTime BOOKING_DATE { get;set;}
       public DateTime RELEASE_DATE { get; set; }
       public TimeSpan FROM_TIME { get; set; }
       public TimeSpan TO_TIME { get; set; }
       public string USER_EMAIL { get; set; }
    }
}
