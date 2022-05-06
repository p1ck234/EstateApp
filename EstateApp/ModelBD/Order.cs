namespace EstateApp.ModelBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public int? StateID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
    }
}
