using Identity.Backend.Data;
using Identity.Backend;
using Identity.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AuthDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exeption)
    {

    }
}

//var authOptions = builder.Configuration.GetSection("Auth").Get<AuthOptions>();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.RequireHttpsMetadata = false;
//        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = authOptions.Issuer,
//            ValidateAudience = true,
//            ValidAudience = authOptions.Audience,
//            ValidateLifetime = true,
//            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
//            ValidateIssuerSigningKey = true
//        };
//    });

//builder.Services.AddAuthorization(options =>
//{
//    options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
//    .RequireAuthenticatedUser()
//    .Build();
//});


//string connection = builder.Configuration.GetValue<string>("DbConnection");

//builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlite(connection));

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



//builder.Services.Configure<AuthOptions>(authOptions);




var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();