using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfExample.Models.EfConfiguration
{
    public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfiguration()
        {
            this.Property(p => p.LastName).IsRequired().HasMaxLength(100);
        }
    }
}
