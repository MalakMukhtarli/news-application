using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Core.Extensions;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;
using NewsApplication.Persistence.Context;
using NewsApplication.Persistence.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// services.InstallServicesInAssembly(builder.Configuration);

services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(identityOption =>
    {
        identityOption.Password.RequiredLength = 8;
        identityOption.Password.RequireDigit = true;
        identityOption.Password.RequireUppercase = false;
        identityOption.Password.RequireLowercase = true;
        identityOption.Password.RequireNonAlphanumeric = false;

        identityOption.User.RequireUniqueEmail = false;

        identityOption.Lockout.MaxFailedAccessAttempts = 5;  //nece defe sehv yazandan sonra block etsin
        identityOption.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); 
        identityOption.Lockout.AllowedForNewUsers = true; //yeni qeydiyyatdan kecibse icaze versin sehv yazmaga
    })
    .AddEntityFrameworkStores<IdentityDbContext<User, IdentityRole<int>, int>>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
services.AddDbContext<IdentityDbContext<User, IdentityRole<int>, int>, NewsAppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();