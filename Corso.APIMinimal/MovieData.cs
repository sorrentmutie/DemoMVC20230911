using Corso.Core.DTO;
using Corso.Core.Entities.Movies;
using Corso.Core.Interfaces;
using Corso.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Corso.APIMinimal;

public class MovieData : IMovieData
{
    private readonly ApplicationDbContext database;

    public MovieData(ApplicationDbContext database)
    {
        this.database = database;
    }

    public async Task<GenreDTO> CreateGenre(GenreDTOCreation genre)
    {
        var genreDb = new Genre { Name = genre.Name };
        database.Genres.Add(genreDb);
        await database.SaveChangesAsync();
        var genreDTO = new GenreDTO { Id = genreDb.Id, Name = genreDb.Name };
        return genreDTO;
    }

    public async Task<int> CreateMovie(Movie movie)
    {
        database.Movies.Add(movie);
        await database.SaveChangesAsync();
        return movie.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var genre = await database.Genres.FindAsync(id);
        if(genre == null) return false;
        database.Genres.Remove(genre);
        await database.SaveChangesAsync();
        return true;
    }

    public async Task<GenreDTO?> GetById(int id)
    {
        var genre = await database.Genres.FindAsync(id);
        if (genre == null) return null;
        return new GenreDTO
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }

    public async Task<IEnumerable<GenreDTO>> GetGenres()
    {
        return await database.Genres
            .Select(x => new GenreDTO { Id = x.Id, Name = x.Name }).ToListAsync();
    }

    public async Task<MovieDTO?> GetMovieById(int id)
    {
        var movie = await database.Movies
            .Include(x => x.Comments)
            .Include(x => x.Genres)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (movie == null) return null;
        return new MovieDTO
        {
            Id = movie.Id,
            Title = movie.Title,
            Comments = movie.Comments.Select(x => new CommentDTO
            {
                Id = x.Id,
                Body = x.Body,
                Reccomend = x.Reccomend
            }).ToList(),
            Genres = movie.Genres.Select(x => new GenreDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList()
        };
    }

    public async Task<GenreDTO?> Update(int id, GenreDTOCreation genre)
    {
        var genreDb = await database.Genres.FindAsync(id);
        if (genreDb == null) return null;
        genreDb.Name = genre.Name;
        await database.SaveChangesAsync();
        return new GenreDTO { Id = genreDb.Id, Name = genreDb.Name };
    }
}
