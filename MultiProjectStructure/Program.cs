using Microsoft.Extensions.Configuration;
using MultiProjectStructure.BussinesLogic;

namespace MultiProjectStructure
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



            builder.Services.AddMemoryCache();
            // builder.Services.AddResponseCaching(); //response caching



            builder.Services.AddBusinessLogic();
            builder.Services.AddDatabase(builder.Configuration.GetConnectionString("Database"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            //app.UseResponseCaching();//response caching


            app.MapControllers();

            app.Run();
        }
    }
}
