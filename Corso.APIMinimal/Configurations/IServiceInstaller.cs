namespace Corso.APIMinimal.Configurations;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, 
                 IConfiguration configuration);
}
