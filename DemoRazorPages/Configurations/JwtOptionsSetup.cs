using Microsoft.Extensions.Options;

namespace DemoRazorPages.Configurations;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration configuration;
    private string sectionName = "Jwt";

    public JwtOptionsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(sectionName)
            .Bind(options);
    }
}
