using Corso.Core.DTO;
using Corso.Core.Entities.Movies;

namespace Corso.Core.Interfaces;

public interface IMovieData
{
    Task<IEnumerable<GenreDTO>> GetGenres();
    Task<GenreDTO> CreateGenre(GenreDTOCreation genre);
    Task<GenreDTO?> GetById(int id);
    Task<GenreDTO?> Update(int id, GenreDTOCreation genre);
    Task<bool> Delete(int id);  
    Task<int> CreateMovie(Movie movie);
    Task<MovieDTO?> GetMovieById(int id);
}
