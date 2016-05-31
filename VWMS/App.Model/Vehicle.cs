namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        [StringLength(50)]
        public string VehicleID { get; set; }

        public int? BrandID { get; set; }

        public int? ModelId { get; set; }

        [StringLength(50)]
        public string EngineNumber { get; set; }

        [StringLength(50)]
        public string ChassiNumber { get; set; }

        public string Discription { get; set; }

        public int? OwnerID { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime? RegDate { get; set; }

        [StringLength(500)]
        public string Url { get; set; }
    }
}
