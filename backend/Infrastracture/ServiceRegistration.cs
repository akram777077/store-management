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
using Microsoft.AspNetCore.Identity;
using Infrastracture.Interseptors;

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

            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseNpgsql(connectionStr).AddInterceptors(
                new SoftDeleteInterceptor());
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // SighnIn settings.

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            return services;

        }
    }
}
