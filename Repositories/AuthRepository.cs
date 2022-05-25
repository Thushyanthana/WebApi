using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataBaseContext;
using WebApi.Entity;
using static WebApi.Entity.Enum.RoleModel;

namespace WebApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly WebApiDBContext _context;
        public AuthRepository(WebApiDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserCredentialModel>> getAuth()
        {
            var authDetails = await _context.UserCredentialModels.ToListAsync();

            return authDetails;
        }

        public async Task<UserCredentialModel> PostAuth(UserCredentialModel user)
        {
            var authDetails = await _context.UserCredentialModels.AddAsync(user);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return (authDetails.Entity);
        }

        public async Task<UserCredentialModel>  getUsernameps(int StudentId)
            {
            var User = await _context.UserCredentialModels.SingleOrDefaultAsync(x=>StudentId==x.Id);
            return User;
            }

        public async Task<int>  getUserID(string username)
        { 
            var user = await _context.UserCredentialModels.SingleOrDefaultAsync(x=> x.UserName== username);
            return user.Id;
        }



        public async Task<RoleModelclass> getUserRole(string  username)
        {
            var role = await _context.UserCredentialModels.SingleOrDefaultAsync(x=> x.UserName== username);
            return role.Role;
        }

    }
}
