using MHMovieDatabase.IMDB.Entities;

namespace MHMovieDatabase.IMDB.Database;

public interface IMovies
{
    List<Movie> Movies();
    List<Movie> Slice(int startIndex, int count);
    List<Movie> Page(int page, int wordLimit);
    int Count();
}