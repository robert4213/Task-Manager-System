using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using TaskManager.Infrastructure.Data;
using AutoMapper;
using TaskManager.Core.Entities;
using TaskManager.Core.MapperProfile;
using TaskManager.Core.Model.Response;
using TaskManager.Core.RepositoryInterface;
using TaskManager.Core.ServiceInterface;
using TaskManager.Infrastructure.Repository;
using TaskManager.Infrastructure.Service;

namespace TaskManager.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TaskManager.API", Version = "v1"});
            });
            
            services.AddDbContext<TaskManagerDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TaskManagerDBConnection"));
            });

            services.AddAutoMapper(typeof(TaskMappingProfile));

            services.AddScoped<IAsyncRepository<User>, EfRepository<User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAsyncRepository<Tasks>, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IAsyncRepository<TaskHistory>, TaskHistoryRepository>();
            services.AddScoped<ITaskHistoryService, TaskHistoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}