using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.ResponseModel;

namespace WebApi.Services
{
    public  interface IGradeStudentService
    {
        Task<List<Student>> getAll();

      

        Task<Student> postStud(Student stud);

        string updateStudent(Student stud, int Id);

        string DeleteStud(int Id);

        Task<List<Grade>> getAllGrades();
        Grade getaSinglegrade(int Id);
        Task<Grade> postGrade(Grade gr);
        string updateaGrade(Grade g, int Id);
        string deleteaGrade(int Id);
        Task<StudentResDatamodel> studGradeID(int GradeId);

        //Admin
        Task<List<Admin>> getAllad();
        Task<Admin> postAd(Admin ad);

        //Lecture
        Task<List<Lecture>> getAllLec();
        Task<Lecture> postLec(Lecture ad);

    }
}
