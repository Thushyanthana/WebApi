using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.DataBaseContext
{
    public class WebApiDBContext:DbContext
    {
        public WebApiDBContext(DbContextOptions<WebApiDBContext> options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>()
            //    .HasOne<UserCredentialModel>(s => s.UserCredentialModel)
            //    .WithOne(ad => ad.Student)
            //    .HasForeignKey<UserCredentialModel>(ad => ad.StudentId);

    //        modelBuilder.Entity<Grade>()
    //.HasMany<Student>(g => g.Students)
    //.WithOne(s => s.Gradesingle)
    //.HasForeignKey(s => s.GradeId);

    //        modelBuilder.Entity<Lecture>()
    //    .HasOne(a => a.UserCredentialModel)
    //    .WithOne(b => b.)
    //    .HasForeignKey<UserCredentialModel>(b => b.UseruniqueId);

            //modelBuilder.Entity<Student>()
            //.HasOne<Grade>(s => s.Grade)
            //.WithMany(g => g.Students)
            //.HasForeignKey(s => s.CurrentGradeId);
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserCredentialModel> UserCredentialModels { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Admin> Admins { get; set; }



    } 
}
