namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            VehicleJobTaskItems = new HashSet<VehicleJobTaskItem>();
        }

        public int ID { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Discription { get; set; }

        public double? PriceIn { get; set; }

        public double? PriceOut { get; set; }

        public int? Quantity { get; set; }

        public int? ReorderLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleJobTaskItem> VehicleJobTaskItems { get; set; }
    }
}
