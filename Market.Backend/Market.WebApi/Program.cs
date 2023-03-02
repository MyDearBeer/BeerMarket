
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Market.Application;
using Market.Application.Common.Mapping;
using Market.Application.Interfaces;
using System.Reflection;
using Market.Persistance

;
using Market.WebApi.Middleware;
using System;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Identity.Common;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<MarketDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exeption)
    {

    }
}

var authOptions = builder.Configuration.GetSection("Auth").Get<AuthOptions>();

//builder.Services.Configure<AuthOptions>(authOptions);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = authOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });
//builder.Services.AddAuthorization(options =>
//{
//    options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
//    .RequireAuthenticatedUser()
//    .Build();
//});

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(
        new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(
        new AssemblyMappingProfile(typeof(IMarketDbContext).Assembly));
});


builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
     .AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );

builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("Auth"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.Run();