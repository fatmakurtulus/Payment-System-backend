//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PaymentSys.Bll;
using PaymentSys.Dal.Abstract;
using PaymentSys.Dal.Concrete.EntityFramework.Context;
using PaymentSys.Dal.Concrete.EntityFramework.Repository;
using PaymentSys.Dal.Concrete.EntityFramework.UnitofWork;
using PaymentSys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.WebApi
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
            #region JwtTokenService
            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(cfg =>
            //    {
            //        cfg.SaveToken = true;
            //        cfg.RequireHttpsMetadata = false;

            //        cfg.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = false,
            //            ValidIssuer = Configuration["Tokens:Issuer"],
            //            ValidAudience = Configuration["Tokens:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
            //            RequireSignedTokens = true,
            //            RequireExpirationTime = true,
            //        };


            //    });
            #endregion

            #region ApplicationContext
            services.AddDbContext<PaymentSysContext>();
            services.AddScoped<DbContext, PaymentSysContext>();
            #endregion


            #region ServiceSection
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IApartmentService, ApartmentManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IPaymentTypeService, PaymentTypeManager>();
            // services.AddScoped<IRequestService, RequestManager>();

            #endregion

            #region RepositorySection
            services.AddScoped<IUserRepository, UserRepository>();
             services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            // services.AddScoped<IRequestRepository, RequestRepository>();

            #endregion
            //services.AddDbContext<PaymentSysContext>(ob=>ob.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            #region UnitOfWork
            services.AddScoped<IUnitofWork, UnitofWork>();
            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentSys.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
           );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentSys.WebApi v1"));
            }

           

            app.UseRouting();
            ////
          //  app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
