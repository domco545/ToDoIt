using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
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
using Newtonsoft.Json;

namespace API
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment Env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            Env = webHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" }); });

            if (Env.IsDevelopment())
                services.AddDbContext<TodoContext>(opt =>
                {
                    opt
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                        .UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=UnitedMarketsSqLite.db")
                        .EnableSensitiveDataLogging(); // BE AWARE ...   only in dev mode
                }, ServiceLifetime.Transient);

            services.AddDbContext<TodoContext>(options =>
            {
                options
                    .UseSqlServer(Configuration["DATABASE_CONNECTION_STRING"])
                    .LogTo(Console.WriteLine);

            });

            services.AddScoped<IAssigneeRepository, AssigneeRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IAssigneeService, AssigneeService>();


            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}