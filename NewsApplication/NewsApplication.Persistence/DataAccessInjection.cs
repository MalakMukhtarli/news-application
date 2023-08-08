using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Persistence.Context;
using NewsApplication.Persistence.Repositories.Concrete;

namespace NewsApplication.Persistence;

public static class DataAccessInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, NewsAppDbContext>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

        return services;
    }
}