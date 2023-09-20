using Corso.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Corso.APIMinimal.Configurations;

public class DatabaseServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services,
               IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
           o => o.UseInMemoryDatabase(configuration["MyDatabase"]));
    }
}
