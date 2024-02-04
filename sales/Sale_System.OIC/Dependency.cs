using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale_system.MODEL.DAL.DBContext;
using Sale_System.DAL.Repositories;
using Sale_System.DAL.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Sale_System.OIC
{
    public static class Dependency
    {
        public static void injectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbSalesContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLString"));
            });
            services.AddTransient(typeof(IGenerictRepository<>),typeof(GenerictRepository<>));
            services.AddScoped<ISaleRepository, Sale_Repository>();
        }
    }
}
