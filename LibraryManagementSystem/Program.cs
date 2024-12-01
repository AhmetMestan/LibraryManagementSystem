
using LibraryManagementSystem.Models.Repositories;
using LibraryManagementSystem.Models.Repositories.Entities;
using LibraryManagementSystem.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("SqlServer");
            Console.WriteLine($"Connection String: {connectionString}");

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
               
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();  

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
