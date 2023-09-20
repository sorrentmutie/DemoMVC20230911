using Corso.Core.Interfaces;

namespace Corso.APIMinimal.Configurations;

public class ApplicationServicesInstaller: IServiceInstaller
{
    public void Install(IServiceCollection services, 
               IConfiguration configuration)
    {
        services.AddScoped<IMovieData, MovieData>();
    }
}
