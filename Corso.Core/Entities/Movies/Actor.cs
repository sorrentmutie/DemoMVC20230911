

namespace Corso.Core.Entities.Movies;

public class Actor: DatabaseEntity
{
    public string? Name { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; } 
    public HashSet<MovieActor> MoviesActors { get; set; } = new HashSet<MovieActor>();
}
