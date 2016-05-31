namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleJobTaskLabour")]
    public partial class VehicleJobTaskLabour
    {
        public int ID { get; set; }

        public int? TaskId { get; set; }

        public int? LabourId { get; set; }

        [StringLength(50)]
        public string Discription { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public int? IsClosed { get; set; }

        public DateTime? OpenDateTime { get; set; }

        public DateTime? CloseDateTime { get; set; }
    }
}
