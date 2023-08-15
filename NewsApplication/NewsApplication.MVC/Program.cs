using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NewsApplication.Application.EntityCQ.Admin.Announcements.Commands;
using NewsApplication.Application.EntityCQ.Announcements.Queries;
using NewsApplication.Models.Entities;
using NewsApplication.MVC.Filters;
using NewsApplication.Persistence.Installers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.InstallServicesInAssembly(builder.Configuration);
services.AddAutoMapper(typeof(Program));
services.AddIdentity<User, IdentityRole<int>>(identityOption =>
    {
        // identityOption.Password.RequiredLength = 5;
        identityOption.Password.RequireDigit = false;
        identityOption.Password.RequireUppercase = false;
        identityOption.Password.RequireLowercase = false;
        identityOption.Password.RequireNonAlphanumeric = false;

        identityOption.User.RequireUniqueEmail = true;

        identityOption.Lockout.MaxFailedAccessAttempts = 5;  //nece defe sehv yazandan sonra block etsin
        identityOption.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); 
        identityOption.Lockout.AllowedForNewUsers = true; //yeni qeydiyyatdan kecibse icaze versin sehv yazmaga
    })
    .AddEntityFrameworkStores<IdentityDbContext<User, IdentityRole<int>, int>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });
// Add services to the container.
builder.Services.AddControllersWithViews(opt=>opt.Filters.Add<ApiExceptionFilterAttribute>());

// services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(AnnouncementPostCommand).Assembly,
    typeof(GetAnnouncementQuery).Assembly
));

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Announcement}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name : "areas",
        pattern : "{area:exists}/{controller=Announcement}/{action=Index}/{id?}"
    );
});

app.Run();