using Core;
using Core.Filters;
using Core.MiddleWare;
using Data.Entities.Identity;
using dotenv.net;
using Infrastracture;
using Infrastracture.DataSeeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using ServiceLayer;
using System.Globalization;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    IEnumerable<CultureInfo> supportedCultures = new List<CultureInfo>()
        {
            new CultureInfo("ar-EG"),
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("en-GB")
        };

    options.DefaultRequestCulture = new RequestCulture("ar-EG");
    options.SupportedCultures = supportedCultures.ToList();
    options.SupportedUICultures = supportedCultures.ToList();
});

#endregion

var configuration = builder.Configuration;
#region Dependency injection
builder.Services.AddInfrastractureDependencies()
    .AddServiceDependencies().AddCoreDependencies().AddServiceRegistration();
#endregion

#region CORS
var _cors = "AllowAll";
//var _ourDomain = "www.ourdomain1.com";
//var _ourDomain2 = "www.ourdomain2.com";
builder.Services.AddCors(options => options.AddPolicy(name: _cors, policy =>
{
    //policy.WithOrigins(_ourDomain,_ourDomain2);
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    //policy.AllowCredentials();  // Allow sending cookies/auth headers
}));
#endregion

builder.Services.AddTransient<AuthFilter>();
var app = builder.Build();

#region DataSeeding
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var rolManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    await RoleSeeder.SeedAsync(rolManager);
    await UserSeeder.SeedAsync(userManager);
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => 
    {
        options.Title = "Store API";
        options.DefaultHttpClient = new (ScalarTarget.CSharp,ScalarClient.HttpClient);
        options.CustomCss="";
    });
}

#region Localization middleware

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options!.Value);

#endregion



app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors(_cors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
