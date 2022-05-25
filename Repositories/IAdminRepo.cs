using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Repositories
{
    public interface IAdminRepo
    {
        Task<List<Admin>> getAllAdmins();
        Task<Admin> postOneAdmin(Admin Ad);
    }
}
