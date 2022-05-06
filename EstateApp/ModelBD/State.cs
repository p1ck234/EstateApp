namespace EstateApp.ModelBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("State")]
    public partial class State
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        public double? Area { get; set; }

        [Column(TypeName = "money")]
        public decimal CostArea { get; set; }

        public int Floor { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public string Description { get; set; }

        [StringLength(1000)]
        public string MainImagePage { get; set; }
    }
}
