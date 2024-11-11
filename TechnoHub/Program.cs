
using TechnoHub.Repositories;
using TechnoHub.Service;
using TechnoHub.Validators;

namespace TechnoHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<CourseRepository>();
            builder.Services.AddScoped<CourseService>();

            builder.Services.AddScoped<UserValidator>();
            builder.Services.AddScoped<UserUpdateValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
