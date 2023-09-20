using System.ComponentModel.DataAnnotations;
namespace Corso.Core.Entities.Events;

public class EventListElement
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Location is required")]
    [StringLength(50, ErrorMessage = "Location must be less than 50 characters")]
    public string? Location { get; set; }
    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }    
}
