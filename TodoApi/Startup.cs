using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Storage;
using TodoApi.Middlewares;
using TodoApi.Storage.Repositories;
using TodoApi.Services;
using AutoMapper;
using TodoApi.Attributes;

namespace TodoApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAllHeaders",
            //        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            //        );
            //});

            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

            //services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ModelValidationFilterAttribute()); // an instance
            });

            
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<LustDbContext>(
                options => options.UseSqlServer(
                     Configuration.GetConnectionString("LustDbConnection")));

            services.AddSingleton<IOLPRRRepository, OLPRRRepository>();
            services.AddScoped<IOLPRRService, OLPRRService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");
            //app.UseCors("AllowAllHeaders");

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvc();

         }
        }
    }

