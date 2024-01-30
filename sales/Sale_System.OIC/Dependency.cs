using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale_system.MODEL.DAL.DBContext;
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
        }
    }
}
