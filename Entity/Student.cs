using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entity
{
    public class Student
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public int GradeId { get; set; }
      
        public virtual Grade Gradesingle { get; set; }
        
        public virtual UserCredentialModel UserCredentialModel{ get; set; }
}
}
