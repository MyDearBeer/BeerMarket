using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyMarket;
using MyMarket.Models;

namespace MyMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {

           

            

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
     .AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );

            builder.Services.AddCors(c=>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<MarketContext>(options => options.UseSqlServer(connection));

            var app = builder.Build();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.MapGet("/api/users", async (MarketContext db) => await db.Users.ToListAsync());

            app.MapGet("/api/users/{id:int}", async (int id, MarketContext db) =>
            {
                User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null) return Results.NotFound(new { message = "������������ �� ������" });
                return Results.Json(user);
            });

            app.MapDelete("/api/users/{id:int}", async (int id, MarketContext db) =>
            {
                // �������� ������������ �� id
                User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

                // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
                if (user == null) return Results.NotFound(new { message = "������������ �� ������" });

                // ���� ������������ ������, ������� ���
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.Json(user);
            });

            app.MapPost("/api/users", async (User user, MarketContext db) =>
            {
                // ��������� ������������ � ������
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                return user;
            });

            app.MapPut("/api/users", async (User userData, MarketContext db) =>
            {
                // �������� ������������ �� id
                var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userData.Id);

                // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
                if (user == null) return Results.NotFound(new { message = "������������ �� ������" });

                // ���� ������������ ������, �������� ��� ������ � ���������� ������� �������
                user.Email = userData.Email;
                user.Name = userData.Name;
                user.Password = userData.Password;
                user.Role = userData.Role;
                await db.SaveChangesAsync();
                return Results.Json(user);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"Photos")),
                RequestPath = "/Photos"
            });

            app.UseRouting();

        

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}

