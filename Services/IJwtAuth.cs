using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.ResponseModel;

namespace WebApi.Services
{
    public interface IJwtAuth
    {

        Task<List<UserCredentialModel>> getAuthdata();
        Task<UserCredentialModel> PostAuthData(UserCredentialModel user);
        //string Authentication(string username, string password);
        Task<string> Authentication(string username, string password);
        Task<UserCredentialStudModel> getuserData(int StudentId);
    }
}
