using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using static WebApi.Entity.Enum.RoleModel;

namespace WebApi.Repositories
{
 public   interface IAuthRepository
    {
        Task<List<UserCredentialModel>> getAuth();
        Task<UserCredentialModel> PostAuth(UserCredentialModel user);
        Task<UserCredentialModel> getUsernameps(int StudentId);
        Task<int> getUserID(string username);
        Task<RoleModelclass> getUserRole(string username);
    }
}
