namespace EfExample.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EfExample.Models.EfConfiguration;

    public partial class BazaDanych : DbContext
    {
        public BazaDanych()
            : base("name=BazaDanych")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Subject> Student_Subject { get; set; }
        public virtual DbSet<Study> Studies { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Configurations.Add(new StudentEntityConfiguration());

        }
    }
}
