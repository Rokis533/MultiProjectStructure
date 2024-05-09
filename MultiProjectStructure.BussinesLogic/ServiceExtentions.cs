using Microsoft.Extensions.DependencyInjection;
using MultiProjectStructure.BussinesLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiProjectStructure.BussinesLogic
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
