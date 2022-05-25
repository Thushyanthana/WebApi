using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Repositories
{
 public   interface ILectureRepository
    {
        Task<List<Lecture>> getAllLectures();
        Task<Lecture> getOneLecture(int Id);
        Task<Lecture> postOneLecture(Lecture le);
    }
}
