namespace Corso.APIMinimal.Configurations;

public class CachingServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddOutputCache();
    }
}
