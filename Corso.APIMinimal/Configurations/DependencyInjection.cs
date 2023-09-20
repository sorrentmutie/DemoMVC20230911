using Corso.Core.Interfaces;
using Corso.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Corso.APIMinimal.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddCaching(
        this IServiceCollection services)
    {
        services.AddOutputCache();
        return services;
    }

    public static IServiceCollection AddDbContext(
               this IServiceCollection services,
               IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            o => o.UseInMemoryDatabase(configuration["MyDatabase"]));
        return services;
    }

    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        return services.AddScoped<IMovieData, MovieData>();
    }


    public static IServiceCollection InstallServices(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        IEnumerable<IServiceInstaller> installers =   
            assemblies.SelectMany(a => a.DefinedTypes)
            .Where(IsAssignableToType<IServiceInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        foreach (IServiceInstaller installer in installers)
        {
            installer.Install(services, configuration);
        }

        return services;
    }

    static bool IsAssignableToType<T>(TypeInfo typeInfo)
    {
        return typeof(T).IsAssignableFrom(typeInfo)
             &&
             !typeInfo.IsInterface
             &&
             !typeInfo.IsAbstract;
    }


}
