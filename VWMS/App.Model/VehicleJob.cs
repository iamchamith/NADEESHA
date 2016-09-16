namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleJob
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleJob()
        {
            VehicleJobTasks = new HashSet<VehicleJobTask>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string VehicleNumber { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public int? IsFinished { get; set; }

        public DateTime? CloseDate { get; set; }

        public DateTime? CloseTime { get; set; }

        public DateTime? OpenDate { get; set; }

        public DateTime? OpenTime { get; set; }

        public double? FinalAmount { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleJobTask> VehicleJobTasks { get; set; }
    }
}
