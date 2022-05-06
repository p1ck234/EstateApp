using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EstateApp.ModelBD
{
    public partial class BaseModel : DbContext
    {
        public BaseModel()
            : base("name=BaseModel")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<State>()
                .Property(e => e.CostArea)
                .HasPrecision(19, 4);
        }
    }
}
