using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entity
{
    public class Lecture
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name  { get; set; }
 
        public virtual UserCredentialModel UserCredentialModel { get; set; }
    }
}
