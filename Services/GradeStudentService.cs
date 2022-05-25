using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Repositories;
using WebApi.ResponseModel;

namespace WebApi.Services
{
    public class GradeStudentService: IGradeStudentService
    {
        private readonly IStudentRepo _studrepo;
        private readonly IGradeRepo _gradeRepo;
        private readonly IAdminRepo _adminRepo;
        private readonly ILectureRepository _lecRepo;

        public GradeStudentService(IStudentRepo studrepo, IGradeRepo gradeRepo, 
            IAdminRepo adminRepo, ILectureRepository lecRepo)
        {
            _studrepo = studrepo;
            _gradeRepo = gradeRepo;
            _adminRepo = adminRepo;
            _lecRepo = lecRepo;

        }


        public async Task<StudentResDatamodel>  studGradeID(int GradeId)
        {
            var stud = await  _studrepo.getStdentByGradeId(GradeId); ;
            var grade = _gradeRepo.getOneGrade(GradeId);
          

            var Result = new StudentResDatamodel()
            {
           students=  stud,
            gradeId = grade.Id
            };
            return Result;
        }



        public async Task<List<Student>> getAll()
        {
            var Students = await _studrepo.getAllstudents();
            return Students;
        }


       


        public async Task<Student>  postStud( Student stud)
        {
            var student =await  _studrepo.postSingleStudent(stud);
            return student;
        }


        public string updateStudent(Student stud, int Id)
        {
            var x = _studrepo.updateSingleStudent(stud, Id);
   
            return "Successfully Updated"+x ;

        }

        public string DeleteStud(int Id)
        {
            var student = _studrepo.DeleteStudent(Id);

            return "Successfully Deleted  " + student;
        }


        //Grade
        public async Task<List<Grade>> getAllGrades()
        {
            var Gras = await _gradeRepo.getAllGrades();
            return Gras;
        }

        public Grade getaSinglegrade(int Id)
        {
            var grade = _gradeRepo.getOneGrade(Id);
            return grade;
        }

        public async Task<Grade> postGrade(Grade gr)
        {
            var gra = await _gradeRepo.postOneGrade(gr);
            return gra;
        }

        public string updateaGrade(Grade g, int Id)
        {
            var x = _gradeRepo.updateSingleGrade(g, Id);

            return "Successfully Updated" + x;

        }

        public string deleteaGrade(int Id)
        {
            var gr = _gradeRepo.DeleteGrade(Id);

            return "Successfully Deleted  " + gr;
        }


        //Admin
        public async Task<List<Admin>> getAllad()
        {
            var ads = await _adminRepo.getAllAdmins();
            return ads;
        }


        public async Task<Admin> postAd(Admin ad)
        {
            var adm = await _adminRepo.postOneAdmin(ad);
            return adm;
        }

        //Lecture
        public async Task<List<Lecture>> getAllLec()
        {
            var lec = await _lecRepo.getAllLectures();
            return lec;
        }

        public async Task<Lecture> postLec(Lecture ad)
        {
            var lec = await _lecRepo.postOneLecture(ad);
            return lec;
        }


    }
}
