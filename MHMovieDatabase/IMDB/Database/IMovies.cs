using MHMovieDatabase.IMDB.Entities;

namespace MHMovieDatabase.IMDB.Database;

public interface IMovies
{
    List<Movie> Movies();
    List<Movie> Movies(int startIndex, int count);
    int Count();
}