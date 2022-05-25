using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WebApi.Entity.Enum.RoleModel;

namespace WebApi.Entity
{
    public class UserCredentialModel
    {
        [Required]
        public int Id{get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        public RoleModelclass Role { get; set; }

        [Required]
        public int  UseruniqueId{get; set; }


       // public virtual RoleModelclass. { get; set; }
}
}
