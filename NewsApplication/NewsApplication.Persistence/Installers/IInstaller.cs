﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NewsApplication.Persistence.Installers;

public interface IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration);
}