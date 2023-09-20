using Microsoft.JSInterop;

namespace Corso.BlazorLibrary.Interop;

public class HelloHelper
{
    public string Name { get; set; } = string.Empty;
    
    public HelloHelper(string name)
    {
        Name = name;        
    }

    [JSInvokable]
    public string SayHello()
    {
        return $"Ciao, {Name}!";
    }
}
