namespace Corso.Core.Entities.Movies;

public class Comment: DatabaseEntity
{
    public string Body{ get; set;} = null!;
    public bool Reccomend { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
}
