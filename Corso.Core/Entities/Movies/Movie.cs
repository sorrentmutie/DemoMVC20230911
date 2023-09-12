﻿namespace Corso.Core.Entities.Movies;

public  class Movie: DatabaseEntity
{
    public string? Title { get; set; }
    public bool IsReleased { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? Plot { get; set; }  
    public string? Poster { get; set; }
    public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();
}
