namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string CustomerMessage { get; set; }

        public DateTime? BookingDate { get; set; }

        public TimeSpan? BookingTime { get; set; }

        [StringLength(50)]
        public string AdmitUserName { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleNumber { get; set; }
    }
}
