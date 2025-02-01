using Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastracture.Data;
using dotenv.net;

namespace Infrastracture
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            
            //Connection SQL
            var connectionStr = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
            //var conn = "Host=localhost;Port=5432;Database=dbmangment;Username=postgres;Password=123;";
            if (string.IsNullOrEmpty(connectionStr))
            {
                throw new InvalidOperationException("Database connection string is not configured.");
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionStr);
            });
            return services;

        }
    }
}
