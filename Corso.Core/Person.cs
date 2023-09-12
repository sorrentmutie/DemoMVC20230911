using Corso.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Corso.Core;

public class Person: IEntity<Guid>
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }
}
