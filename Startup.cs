using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataBaseContext;
using WebApi.Repositories;
using WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var _key = "This is my first Test Key";
       
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                //to save the token in .net in vs
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    //validate the key
                    ValidateIssuerSigningKey = true,
                    //Buble town
                    ValidateIssuer = false,
                    //Customer/Vendor
                    ValidateAudience = false,
                    //encode and bytes
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key))
                };
            });

            //services.AddSingleton<IJwtAuth, IJwtAuth>(new AuthService(_key));
            //AddScoped It is used to create every time instance in Database
            //AddSingleton It is used to create only when run the project it will be call

            services.AddScoped<IJwtAuth, AuthService>();
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddDbContext<WebApiDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnString")));
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<IGradeRepo, GradeRepo>();
            services.AddScoped<IGradeStudentService, GradeStudentService>();
            services.AddScoped<IJwtAuth, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<ILectureRepository, LectureRepository>();
            services.AddScoped<IAdminRepo, AdminRepo>();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();     
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //We need to Enable Authentication in middleware to validate members.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
