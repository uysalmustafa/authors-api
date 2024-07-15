using AuthorsAPI.Context;
using AuthorsAPI.DTO;
using AuthorsAPI.Services;
using AuthorsAPI.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace AuthorsAPI
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
         
            // Add services to the container.
            var connectionStringSql = Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<AuthorsDbContext>(options => options.UseSqlServer(connectionStringSql));

            services.AddControllers();

            services.AddScoped<IAuthorService, AuthorService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<AuthorCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<AuthorUpdateDtoValidator>();

            services.AddTransient<IValidator<AuthorCreateDto>, AuthorCreateDtoValidator>();
            services.AddTransient<IValidator<AuthorUpdateDto>, AuthorUpdateDtoValidator>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthorsAPI v1"));
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
