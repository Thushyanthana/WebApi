using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;

        public UserAuthController(IJwtAuth _jwtAuth)
        {
            jwtAuth = _jwtAuth;
        }

        [HttpGet("UserAuthGet")]
        public async Task<List<UserCredentialModel>> getAuthdata()
        {
            var authDetails = await jwtAuth.getAuthdata();
            return authDetails;
        }

        [HttpPost("UserAuthPost")]
        public async Task<UserCredentialModel> PostAuthData(UserCredentialModel user)
        {
            var authDetails = await jwtAuth.PostAuthData(user);
            return (authDetails);
        }

    
        [AllowAnonymous]      
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] UserCredentialModel userCredential)
        {
            var token = await jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
            {
                return Unauthorized();
            }
 
            return Ok(token);
        }



    }
}
