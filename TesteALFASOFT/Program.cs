using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteALFASOFT.Context;
using Microsoft.EntityFrameworkCore.SqlServer;
using TesteALFASOFT.Repositories;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var conection = builder.Configuration.GetConnectionString("MariaDB");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(conection,
     ServerVersion.Create(new Version(10, 6,11), ServerType.MariaDb)));
    //, MariaDbServerVersion.AutoDetect(new Version(10, 5, 4), ServerType.MariaDb));

builder.Services.AddScoped<IContactRepository, ContactRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
