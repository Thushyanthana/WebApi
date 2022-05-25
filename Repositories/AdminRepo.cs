using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataBaseContext;
using WebApi.Entity;

namespace WebApi.Repositories
{
    public class AdminRepo  : IAdminRepo
    {
        private readonly WebApiDBContext _context;
        public AdminRepo(WebApiDBContext context)
        {
            _context = context;
        }


        public async Task<List<Admin>> getAllAdmins()
        {
            var admins = await _context.Admins.ToListAsync();
           if (admins!=null)
            {
               try{
                    return admins;
                }
                catch(Exception e)
                {
                    throw ;
                }
            }
            return admins;
        }

        public Admin getOneAdmin(int Id)
        {
            var admin = _context.Admins.SingleOrDefault(x => x.Id == Id);
            return admin;
        }

        public async Task<Admin> postOneAdmin(Admin Ad)
        {

            var admin= _context.Admins.Add(Ad);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return admin.Entity;
        }


        public string updateSingleAdmin(Admin ad, int Id)
        {
            if (ad.Id == Id)
            {
                _context.Entry(ad).State = EntityState.Modified;
                _context.SaveChanges();
                return "Successfully updated "+ Id;
            }
            else
            {
                return "Id not Found ";
            }

        }

        public string DeleteAdmin(int Id)
        {
            var ad = _context.Admins.SingleOrDefault(x => x.Id == Id);

            if (ad != null)
            {
                _context.Admins.Remove(ad);
                _context.SaveChanges();
                return "Successfully Deleted  " + ad.Id;
            }
            else
            {
                return "Id is Not there Cannot delete a Admin";
            }
        }



    }
}
