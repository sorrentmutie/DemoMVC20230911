namespace Corso.Core.Entities.Events;

public class EventListElement
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string? Location { get; set; } 
    public string? Description { get; set; }    
}
