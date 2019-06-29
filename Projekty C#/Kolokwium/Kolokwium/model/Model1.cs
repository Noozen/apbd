namespace Kolokwium.model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalType> AnimalTypes { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AnimalType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }
}
