namespace App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TaskName { get; set; }

        public string Discription { get; set; }
    }
}
