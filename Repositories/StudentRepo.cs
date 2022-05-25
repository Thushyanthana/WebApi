using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataBaseContext;
using WebApi.Entity;

namespace WebApi.Repositories
{
    public class StudentRepo: IStudentRepo
    {
        private readonly WebApiDBContext _context;
        public StudentRepo(WebApiDBContext context)
        {
            _context = context;
        }

        public async Task<List<Student>>  getStdentByGradeId(int GradeId)
        {
           
          var  student =  _context.Students.Where(x=> x.GradeId== GradeId).ToList();
            return student;
        }
        public async Task<List<Student>> getAllstudents()
        {
            
            var Students =await  _context.Students.ToListAsync();
            if(Students!=null)
            {
                return Students;
            }
            return new List<Student>();
        }

        public async Task<Student> getaSingleStudent(int StudentId)
        {
            var student =await  _context.Students.SingleOrDefaultAsync(x => StudentId==x.Id );
            return student;
        }


        public async Task<Student>  postSingleStudent( Student stud)
        {
            
            var student =  _context.Students.Add(stud);
            await  _context.SaveChangesAsync().ConfigureAwait(true);
            return student.Entity;
        }


        public string updateSingleStudent(Student stud,int Id)
        {
            if(stud.Id==Id)
            {
                _context.Entry(stud).State = EntityState.Modified;
                _context.SaveChanges();
                return "Successfully updated " + stud.Id;
            }
            else
            {
                return "Id not Found ";
            }           
        }

        public string DeleteStudent(int Id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == Id);

            if(student!=null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return "Successfully Deleted  " + student.Id;
            }
           
            return "Successfully Deleted  " +student.Id;
        }




    }
}
