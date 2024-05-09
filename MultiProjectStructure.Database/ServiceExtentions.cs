using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiProjectStructure.Database;
using MultiProjectStructure.Database.Repositories;

namespace MultiProjectStructure.BussinesLogic
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connnectionString)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddDbContext<BookContext>(options => options.UseSqlServer(connnectionString));

            return services;
        }
    }
}
