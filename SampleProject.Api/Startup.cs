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
using SampleProject.Business.Abstract;
using SampleProject.Business.Concrate;
using SampleProject.Business.Mapping;
using SampleProject.DataAccess.Abstract;
using SampleProject.DataAccess.Concrate;
using SampleProject.DataAccess.Concrate.Ef.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Api
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
            services.AddDbContext<SampleProjectContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CityConnection"));
            }
            );
            services.AddControllersWithViews();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SampleProject.Api", Version = "v1" });
            });
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryRepository, CountryRepository>();


            services.AddAutoMapper(typeof(CustomAutoMapper));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleProject.Api v1"));
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
