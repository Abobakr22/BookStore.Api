using BookStore.Api.Data;
using BookStore.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //add service for db_context with connection string
            builder.Services.AddDbContext<BookStoreContext>(
                options => options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Database= BookStoreApi ;Integrated Security=True;")); 
           
            builder.Services.AddControllers();
            //add Dependency injection service for Book repository
            builder.Services.AddTransient<IBookRepository, BookRepository>();    

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