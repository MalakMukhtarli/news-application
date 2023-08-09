using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsApplication.Models.Entities;

namespace NewsApplication.Core.Installers;

public class DbContextInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext<User, IdentityRole<int>, int>>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}