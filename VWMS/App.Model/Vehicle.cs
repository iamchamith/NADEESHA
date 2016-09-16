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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            VehicleJobs = new HashSet<VehicleJob>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleJob> VehicleJobs { get; set; }
    }
}
