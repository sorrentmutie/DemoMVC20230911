using Corso.Infrastructure.Northwind.Models;
using DemoRazorPages.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NorthwindContext>
    (o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("Northwind")));

builder.Services.ConfigureOptions<JwtOptionsSetup>();

builder.Services.Configure<Features>
    (Features.FirstFeature,
     builder.Configuration.GetSection("Features:FirstFeature"));

builder.Services.AddOptions<MySettingsOptions>()
    .Bind(builder.Configuration.GetSection(
        MySettingsOptions.ConfigurationSectionName))
    .ValidateDataAnnotations();



builder.Services.Configure<Features>
    (Features.SecondFeature,
     builder.Configuration.GetSection("Features:SecondFeature"));

var x = new  MySettingsOptions() { Scale = 1200, Title = "Ciao", VerbosityLevel = 10};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
