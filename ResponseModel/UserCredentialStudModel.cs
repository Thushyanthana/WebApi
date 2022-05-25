using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.ResponseModel
{
    public class UserCredentialStudModel
    {
        public int StudentId { get; set; }
        public UserCredentialModel userAuthInformation { get; set; }

    }
}
