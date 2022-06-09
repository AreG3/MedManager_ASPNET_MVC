using MedManager.Models;
using Microsoft.EntityFrameworkCore;
using MedManager.Repositories;
using Microsoft.AspNetCore.Identity;
using MedManager.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddDbContext<MedManagerContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MedManagerDB;Trusted_Connection=True;"));
builder.Services.AddTransient<IMedRepository, MedTakeRepository>();
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MedTake}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
