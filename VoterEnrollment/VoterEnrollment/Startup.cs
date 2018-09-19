using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace VoterEnrollment
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connectionString: Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
         // Apply CORS policy for any type of origin  
         .AllowAnyMethod()
         // Apply CORS policy for any type of http methods  
         .AllowAnyHeader()
         // Apply CORS policy for any headers  
         .AllowCredentials());
                // Apply CORS policy for all users  

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddLog4Net();
            app.UseMvc();
            app.UseCors("CORS");
        }

    }
}
