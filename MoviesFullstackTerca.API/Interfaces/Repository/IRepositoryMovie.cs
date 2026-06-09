using MoviesFullstackTerca.API.Models;
using MoviesFullstackTerca.API.Request.Movies;

namespace MoviesFullstackTerca.API.Interfaces.Repository;

public interface IRepositoryMovie
{
    bool Create(MovieCreateRequest movie);
    Movie? GetById(int id);
    bool Update(int id, MovieUpdateRequest movie);
    bool Delete(int id);
    List<Movie> GetAll();
}
