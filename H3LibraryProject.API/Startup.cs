using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using H3LibraryProject.Services.Services;
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

namespace H3LibraryProject.API
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
                options.AddPolicy("InitialRules",
                builder =>
                {
                    builder.AllowAnyOrigin() // kan skrive port i stedet for
                           .AllowAnyHeader()
                           .AllowAnyMethod(); // kun get eller put mm.
                });
            });

            services.AddDbContext<LibraryContext>(
                x => x.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "H3LibraryProject.API", Version = "v1" });
            });

            services.AddScoped<ILoanerTypeRepository, LoanerTypeRepository>();
            services.AddScoped<ILoanerTypeService, LoanerTypeService>();

            services.AddScoped<ILoanerRepository, LoanerRepository>();
            services.AddScoped<ILoanerService, LoanerService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILanguageService,LanguageService>();
            services.AddScoped<ILanguageRepository,LanguageRepository>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<INationalityService, NationalityService>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoanService, LoanService>();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<ITitleService, TitleService>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMaterialService, MaterialService>();

            services.AddScoped<INationalityRepository, NationalityRepository>();
            //services.AddScoped<INationalityService, NationalityService>();

            //services.AddScoped<IGenreRepository, GenreRepository>();
            //services.AddScoped<IGenreService, GenreService>();

            //services.AddScoped<ILanguageRepository, LanguageRepository>();
            //services.AddScoped<ILanguageService, LanguageService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "H3LibraryProject.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("InitialRules");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
