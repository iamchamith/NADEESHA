namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model
    {
        public int ID { get; set; }

        public int? BrandId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Discription { get; set; }
    }
}
