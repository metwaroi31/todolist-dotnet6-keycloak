using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using todolist_dotnet6_keycloak.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddSwaggerGen();
        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<TodolistContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("todolist_dotnet6_keycloakContext")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        } else
        {
            Console.WriteLine("This is development");
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.MapRazorPages();

        app.Run();
    }
}
public class TodolistContext : DbContext
{
    public DbSet<UserModel> UserModels { get; set; }
    public TodolistContext(DbContextOptions options) : base(options)
    {
    }

}
