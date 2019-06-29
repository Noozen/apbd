namespace Zad7.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PjatkDb : DbContext
    {
        public PjatkDb()
            : base("name=PjatkDb")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.subjectName)
                .IsUnicode(false);
        }
    }
}
