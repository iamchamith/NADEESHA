namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleJobTaskItem")]
    public partial class VehicleJobTaskItem
    {
        public int ID { get; set; }

        public int? TaskId { get; set; }

        public int? ItemId { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }

        [StringLength(50)]
        public string Discription { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime? RegDate { get; set; }

        public virtual Item Item { get; set; }

        public virtual Task Task { get; set; }
    }
}
