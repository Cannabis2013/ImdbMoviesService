using MHMovieDatabase.IMDB.Entities;
using MHMovieDatabase.Shared.Database;

namespace MHMovieDatabase.IMDB.Database;

public class ImdbDatabaseContext : MyDbContext<Movie>, IMovies
{
    public ImdbDatabaseContext(IDbConnectionDetails dbDetails) : base(dbDetails)
    { }

    public List<Movie> Movies() => Entities.ToList();

    public List<Movie> Movies(int startIndex, int count)
    {
        var max = startIndex + count;
        return Entities
            .Skip(startIndex)
            .Take(count)
            .ToList();
    }

    public int Count() => Entities.Count();
}