namespace DemoMVC.Models;

public interface IWelcome
{
   string? Message(); 
}

public class Welcome : IWelcome
{
    private readonly IConfiguration configuration;

    public Welcome(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public string? Message() => configuration["Saluto"];
}
