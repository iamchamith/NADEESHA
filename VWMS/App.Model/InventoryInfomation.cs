namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryInfomation")]
    public partial class InventoryInfomation
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public int? Qty { get; set; }

        public int? Type { get; set; }

        public DateTime? RegDate { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }
    }
}
