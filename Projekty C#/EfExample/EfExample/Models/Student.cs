namespace EfExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("apbd.Student")]
    public partial class Student //: IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStudent { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required(ErrorMessage ="This is required")]
        [StringLength(100)]
        public string Address { get; set; }

        public int IdStudies { get; set; }
        
        [ForeignKey("IdStudies")]
        public virtual Study Study { get; set; }





        public virtual ICollection<Student_Subject> StudentSubject { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    yield return new ValidationResult
        //          ("Blog Title cannot match Blogger Name", new[] { "Title", "BloggerName" });
        //}
    }
}
