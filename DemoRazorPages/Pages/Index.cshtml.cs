using Corso.Core.Northwind.ViewModels;
using Corso.Infrastructure.Northwind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindContext northwindContext;

        public List<CategoryIndexViewModel>? Categories { get; set; }

        public IndexModel(NorthwindContext northwindContext)
        {
            this.northwindContext = northwindContext;
        }

        public async Task OnGet()
        {
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