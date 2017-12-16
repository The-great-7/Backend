﻿namespace LSS.Api
{
    using System;
    using LSS.Data;
    using LSS.Services;
    using LSS.Services.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ICourseService, CourseService>();
            services.AddDbContext<LSSDbContext>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }


        private IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddDbContext<LSSDbContext>();            
            /*
            services go here
            */
            serviceCollection.AddAutoMapper(cfg =>
                cfg.AddProfile<AutoMapperProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}