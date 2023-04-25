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
        var index = startIndex + 1;
        var max = index + count;
        return Entities
            .Where(m => m.Id >= index && m.Id <= max)
            .ToList();
    }

    public int Count() => Entities.Count();
}