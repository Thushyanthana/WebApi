using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataBaseContext;
using WebApi.Entity;

namespace WebApi.Repositories
{
    public class GradeRepo: IGradeRepo
    {
        private readonly WebApiDBContext _context;
        public GradeRepo(WebApiDBContext context)
        {
            _context = context;
        }



        public async Task<List<Grade>> getAllGrades()
        {

            var Grades = await _context.Grades.ToListAsync();
            if (Grades != null)
            {
                return Grades;
            }
            return new List<Grade>();
        }

        public Grade getOneGrade(int Id)
        {
            var grade = _context.Grades.SingleOrDefault(x => x.Id== Id);
            return grade;
        }

        public async Task<Grade> postOneGrade(Grade grad)
        {

            var grade = _context.Grades.Add(grad);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return grade.Entity;
        }


        public string updateSingleGrade(Grade grad, int Id)
        {
            if (grad.Id == Id)
            {
                _context.Entry(grad).State = EntityState.Modified;
                _context.SaveChanges();
                return "Successfully updated ";
            }
            else
            {
                return "Id not Found ";
            }
          
            //return "Successfully Updated" + grad.GradeId;

        }

        public string DeleteGrade(int Id)
        {
            var grade = _context.Grades.SingleOrDefault(x => x.Id == Id);

            if (grade!=null)
            {
                _context.Grades.Remove(grade);
                _context.SaveChanges();
                return "Successfully Deleted  " + grade.Id;
            }
            else
            {
                return "Id is Not there Cannot delete a grade";
            }

           
        }

    }
}
