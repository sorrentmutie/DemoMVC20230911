using System.ComponentModel.DataAnnotations;

namespace Corso.Core.Northwind.ViewModels;

public class CategoryCreateViewModel
{
    [Required(ErrorMessage = "Category name is required")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Category description is required")]
    public string? Description { get; set; }
}
