using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataBaseContext;
using WebApi.Entity;

namespace WebApi.Repositories
{
    public class LectureRepository: ILectureRepository
    {
        private readonly WebApiDBContext _context;
        public LectureRepository(WebApiDBContext context)
        {
            _context = context;
        }


        public async Task<List<Lecture>> getAllLectures()
        {
            var Lecture = await _context.Lectures.ToListAsync();
            if (Lecture != null)
            {
                try
                {
                    return Lecture;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Lecture ;
        }

        public async   Task<Lecture> getOneLecture(int Id)
        {
            var lec =await  _context.Lectures.SingleOrDefaultAsync(x => x.Id == Id);
            return lec;
        }

        public async Task<Lecture> postOneLecture(Lecture le)
        {
            var lec = await _context.Lectures.AddAsync(le);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return lec.Entity;
        }


    }
}
