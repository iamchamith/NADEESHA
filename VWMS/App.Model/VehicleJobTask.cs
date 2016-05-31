namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleJobTask
    {
        public int ID { get; set; }

        public int? JobId { get; set; }

        public int? TaskId { get; set; }

        public string Discription { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime? Date { get; set; }

        public int? IsClosed { get; set; }

        public double? TaskCost { get; set; }
    }
}
