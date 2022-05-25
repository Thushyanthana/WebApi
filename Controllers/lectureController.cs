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
    public class lectureController : ControllerBase
    {

        private readonly IGradeStudentService IAdminService;
        public lectureController(IGradeStudentService _IAdminService)
        {
            IAdminService = _IAdminService;
        }


        [HttpGet("AllLectures")]
        public async Task<List<Lecture>> getAlllect()
        {
            var les = await IAdminService.getAllLec();
            return les;
        }

        [HttpPost("PLecture")]
        public async Task<Lecture> postLect([FromBody] Lecture le)
        {
            var lec = await IAdminService.postLec(le);
            return lec;
        }

    }
}
