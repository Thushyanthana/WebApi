using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Repositories
{
  public  interface IStudentRepo
    {
        Task<List<Student>> getAllstudents();
        Task<Student> getaSingleStudent(int Id);
        Task<Student> postSingleStudent(Student stud);

        string updateSingleStudent(Student stud, int Id);

        string DeleteStudent(int Id);

        Task<List<Student>> getStdentByGradeId(int GradeId);
    }
}
