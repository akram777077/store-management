using Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastracture.Data;
using Microsoft.AspNetCore.Identity;
using Infrastracture.Interseptors;
using Data.Healper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace Infrastracture
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
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


            services.AddIdentity<User, Role>(options =>
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

            //JWT Authentication

            var jwtSettings = new JwtSettings
            {
                Secret = Environment.GetEnvironmentVariable("JWT_SECRET"),
                Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                ValidateAudience = bool.Parse(Environment.GetEnvironmentVariable("JWT_VALIDATE_AUDIENCE") ?? "true"),
                ValidateIssuer = bool.Parse(Environment.GetEnvironmentVariable("JWT_VALIDATE_ISSUER") ?? "true"),
                ValidateLifeTime = bool.Parse(Environment.GetEnvironmentVariable("JWT_VALIDATE_LIFETIME") ?? "true"),
                ValidateIssuerSigningKey = bool.Parse(Environment.GetEnvironmentVariable("JWT_VALIDATE_ISSUER_SIGNING_KEY") ?? "true"),
                AccessTokenExpireDate = int.Parse(Environment.GetEnvironmentVariable("JWT_ACCESS_TOKEN_EXPIRE_DATE") ?? "1"),
                RefreshTokenExpireDate = int.Parse(Environment.GetEnvironmentVariable("JWT_REFRESH_TOKEN_EXPIRE_DATE") ?? "20")
            };

            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;//change to true in production
                x.SaveToken = true;
            
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuers = new[] { jwtSettings.Issuer },
            
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.Audience,
            
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                    ClockSkew = TimeSpan.Zero // Prevents default 5-minute token expiration delay
                };
            
                // Handle token expiration gracefully
                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("CreateInventoryDetails", policy => policy.RequireClaim("CreateInventoryDetails", "True"));
                option.AddPolicy("DeleteInventoryDetails", policy => policy.RequireClaim("DeleteInventoryDetails", "True"));
                option.AddPolicy("RetriveInventoryDetailsLists", policy => policy.RequireClaim("RetriveInventoryDetailsLists", "True"));
                option.AddPolicy("EditInventoryDetails", policy => policy.RequireClaim("EditInventoryDetails", "True"));
                option.AddPolicy("DeleteBrand", policy => policy.RequireClaim("DeleteBrand", "True"));
                //option.AddPolicy("SendingEmails", policy => policy.RequireClaim("SendingEmails", "True"));
            });

            return services;

        }
    }
}
