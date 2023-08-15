using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Persistence.Repositories.Concrete;

namespace NewsApplication.Persistence.Installers;

public class RepositoryInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();

    }
}