using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

private readonly IGradeStudentService IAdminService;
        public AdminController(IGradeStudentService _IAdminService)
        {
            IAdminService = _IAdminService;
        }


[HttpGet("AllAdmin")]
        public async Task<List<Admin>> getAllad()
        {
            var ads = await IAdminService.getAllad();
            return ads;
        }

[HttpPost("PAdmin")]
        public async Task<Admin> postAd([FromBody]Admin ad)
        {
            var adm = await IAdminService.postAd(ad) ;
            return adm;
        }



    }
}
