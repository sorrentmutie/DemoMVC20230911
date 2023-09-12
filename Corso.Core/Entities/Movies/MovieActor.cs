namespace Corso.Core.Entities.Movies;

public class MovieActor: DatabaseEntity
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }    
    public string? Character { get; set; }
    public int Order { get; set; }
    public Movie Movie { get; set; } = null!;
    public Actor Actor { get; set; } = null!;   
}
