using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Repositories;
using WebApi.ResponseModel;
using static WebApi.Entity.Enum.RoleModel;

namespace WebApi.Services
{
    public class AuthService: IJwtAuth
    {
      private readonly IAuthRepository _IAuthRepository;
        private readonly IStudentRepo _studrepo;
        private readonly string _key;
    

        public AuthService(IAuthRepository IAuthRepository, IStudentRepo studrepo)
        {
            _IAuthRepository = IAuthRepository;
            _studrepo = studrepo;
            this._key = "This is my first Test Key";

        }
        public async Task<List<UserCredentialModel>> getAuthdata()
        {
            var authDetails =await  _IAuthRepository.getAuth();
            return authDetails;
        }

        public async Task<UserCredentialModel> PostAuthData(UserCredentialModel user)
        {
            var authDetails = await  _IAuthRepository.PostAuth(user);
            return (authDetails);
        }

        public async Task<UserCredentialStudModel> getuserData(int StudentId)
        {
            var authDetail = await _IAuthRepository.getUsernameps(StudentId);
            var student = await _studrepo.getaSingleStudent(StudentId);

            var Resut = new UserCredentialStudModel()
            {
                userAuthInformation = authDetail,
                StudentId= student.Id
            };

            return Resut;
        }

        public async Task<string> Authentication(string username, string password)
        {
            if (!(username.Equals(username) || password.Equals(password)))
            {
                return null;
            }

            var Id = await _IAuthRepository.getUserID(username);

            var Role =await _IAuthRepository.getUserRole(username);

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim("UserId", Id.ToString()),                        
                        new Claim(ClaimTypes.Role,Role.ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }



    }
}
