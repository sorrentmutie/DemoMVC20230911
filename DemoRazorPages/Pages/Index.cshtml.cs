using Corso.Core.Northwind.ViewModels;
using Corso.Infrastructure.Northwind.Models;
using DemoRazorPages.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DemoRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindContext northwindContext;
        private readonly ILogger<IndexModel> logger;
        private readonly Features? first;
        private readonly Features? second;
        
        public string FirstKey { get; set; } = "FirstKey";
        public string SecondKey { get; set; } = "FirstKey";

        public List<CategoryIndexViewModel>? Categories { get; set; }

        public IndexModel(NorthwindContext northwindContext,
            IOptionsSnapshot<Features> optionsSnapshot,
            IOptions<MySettingsOptions> options,
            ILogger<IndexModel> logger)
        {
            this.northwindContext = northwindContext;
            this.logger = logger;
            first = optionsSnapshot.Get(Features.FirstFeature);
            second = optionsSnapshot.Get(Features.SecondFeature);

            try
            {
                var optionsValues = options.Value;

            }
            catch (OptionsValidationException ex)
            {

                foreach (var failure in ex.Failures)
                {
                    logger.LogError(failure);
                }
            }

        }

        public async Task OnGet()
        {
            FirstKey = $"FirstKey: {first?.ApiKey}";
            SecondKey = $"SecondKey: {second?.ApiKey}";

            Categories = 
                await (northwindContext.Categories
                .Select(c => new CategoryIndexViewModel
                {
                    CategoryName = c.CategoryName,
                    ProductsNumber = c.Products.Count,
                    Description = c.Description
                })
                .ToListAsync());
        }
    }
}