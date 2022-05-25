using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using WebApi.Entity;
using WebApi.Services;
using static WebApi.Entity.Enum.RoleModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeStudentService _Istudservice;
        private readonly IJwtAuth jwtAuth;
      
        public GradeController(IGradeStudentService Istudservice, IJwtAuth _jwtAuth)             
        {
            _Istudservice = Istudservice;
           jwtAuth = _jwtAuth;
           
        }

        //[HttpGet("ListOfGrades")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpGet("ListOfGrades")]
        public async Task<ActionResult<List<Grade>>> getListOfGrades()
        {


            //var token = actionContext.Request.Headers.Authorization.Parameter;
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ","");



            var handler = new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(token) ;

           

            var Role = decodedValue.Claims.First(claim => claim.Type == "role").Value;
            if ((Role == RoleModelclass.Admin.ToString()) || (Role == RoleModelclass.Lecturer.ToString()))
            {
                var GradList = await _Istudservice.getAllGrades();
                return GradList;
            }
            else
            {
                return Unauthorized();
            }

            return Ok();
           
        }


        [HttpGet("GradeByID/{Id}")]
        public IActionResult getGradeByID(int Id)
        {
            var grad = _Istudservice.getaSinglegrade(Id);
            if (grad == null)
            {
                return NotFound("Grade Table Has No Record");
            }
            return Ok("Successfully Get a Grade" + grad.Id);
        }


        [HttpPost("GradePost")]
        public async Task<IActionResult> postGrade(Grade grad)
        {
            var grade = await _Istudservice.postGrade(grad);
            if (grade == null)
            {
                return NotFound("Grade Table cannot post");
            }
            return Ok("Successfully Added a grade" + grade);
        }


        [HttpPut("GradePut/{Id}")]
        public IActionResult updatestudent(Grade grad, int Id)
        {
            var grade = _Istudservice.updateaGrade(grad, Id);
            if (grade == null)
            {
                return NotFound("Grade Table cannot update");
            }
            return Ok("Successfully update a Grade" + grade);
        }


        [HttpDelete("GradeDelete/{Id}")]
        public IActionResult deleteStudent(int Id)
        {
            var grade = _Istudservice.deleteaGrade(Id);
            if (grade == null)
            {
                return NotFound("Cannot delete Grade Table");
            }
            return Ok("Successfully delete a Grade" + grade);
        }


    }
}
