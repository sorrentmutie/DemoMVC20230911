using Corso.Core.Northwind.ViewModels;
using Corso.Infrastructure.Northwind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPages.Pages
{
    public class CategoryCreationModel : PageModel
    {
        private readonly NorthwindContext context;

        public CategoryCreationModel(NorthwindContext context)
        {
            this.context = context;
        }


        [BindProperty]  
        public CategoryCreateViewModel Category { get; set; }
        = new CategoryCreateViewModel();


        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return RedirectToPage("CategoryCreation");
            }


            context.Categories.Add(
                    new Category
                    {
                        CategoryName = Category.Name,
                        Description = Category.Description
                    });

            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

            
    }
}
