using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Repositories
{
  public  interface IGradeRepo
    {
        Task<List<Grade>> getAllGrades();
        Grade getOneGrade(int Id);
        Task<Grade> postOneGrade(Grade grad);

        string updateSingleGrade(Grade grad, int Id);
        string DeleteGrade(int Id);
    }
}
