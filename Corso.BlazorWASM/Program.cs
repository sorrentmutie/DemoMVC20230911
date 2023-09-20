using Corso.BlazorLibrary;
using Corso.BlazorLibrary.ReqRes;
using Corso.BlazorWASM;
using Corso.BlazorWASM.Services;
using Corso.Core.Entities.Events;
using Corso.Core.ReqRes;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEventsData, StaticEventsData>();
builder.Services.AddHttpClient("reqres", client =>
{
    client.BaseAddress = new Uri("https://reqres.in/api/");
})
.AddTransientHttpErrorPolicy( b =>
        b.WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(60)
        }));

builder.Services.AddScoped<IReqResData, ReqResData>();


await builder.Build().RunAsync();
