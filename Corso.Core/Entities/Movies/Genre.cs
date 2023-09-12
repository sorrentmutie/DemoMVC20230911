namespace Corso.Core.Entities.Movies;

public  class Genre: DatabaseEntity
{
    public string Name { get; set; } = null!;
    public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
}
