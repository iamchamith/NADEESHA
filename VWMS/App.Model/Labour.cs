namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Labour
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Type { get; set; }

        public string Discription { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        [StringLength(50)]
        public string Nic { get; set; }
    }
}
