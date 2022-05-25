using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.ResponseModel;
using WebApi.Services;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IGradeStudentService _Istudservice;
       
        public StudentController(IGradeStudentService Istudservice)
        {
            _Istudservice = Istudservice;
        }
       
        [HttpGet("grStuds/{GradeId}")]
        public async Task<StudentResDatamodel> studentsGradesById(int GradeId)
        {
            var x =await _Istudservice.studGradeID(GradeId);
            return x;
        }

        //[HttpGet("userModelStuds/{stdentId}")]
        //public async Task<UserCredentialStudModel> getStudentUserModel(int stdentId)
        //{
        //    var userStud = await jwtAuth.getuserData(stdentId);

        //    return userStud;
        //}


        [HttpGet("All")]
        public async Task<List<Student>> getStudent()
        {
            var Stud =await  _Istudservice.getAll();
            return Stud ;
        }

        [HttpPost]
        public async Task<IActionResult> postStudent(Student stud)
        {
            var Stud = await _Istudservice.postStud(stud);
            if (Stud == null)
            {
                return NotFound("Student Table cannot post");
            }
            return Ok("Successfully Get a student" + Stud);
        }


        [HttpPut("{id}")]
        public IActionResult updatestudent(Student stud, int Id)
        {
            var Student = _Istudservice.updateStudent(stud, Id);
            if (Student == null)
            {
                return NotFound("Student Table cannot update");
            }
            return Ok("Successfully update a student" + Student);
        }


        [HttpDelete("{Id}")]
        public IActionResult deleteStudent(int Id)
        {
            var Student = _Istudservice.DeleteStud(Id);
            if (Student == null)
            {
                return NotFound(" cannot delete Student Table");
            }
            return Ok("Successfully delete a student" + Student);
        }
        

    }
}
