using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IEMMOB_Model.ASMS.OnboardingModel;

namespace IEMMOB
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
            services.AddControllers();



            services.AddCors();
            
           // services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
           // services.AddScoped<IUserService, UserService>();
            //var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            //XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            //if ((Configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT"))
            //{
                services.Configure<Employee>(Configuration.GetSection("ConnectionString"));
               
            //}
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
