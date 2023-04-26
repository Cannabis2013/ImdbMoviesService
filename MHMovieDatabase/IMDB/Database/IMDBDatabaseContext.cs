using MHMovieDatabase.IMDB.Entities;
using MHMovieDatabase.Shared.Database;

namespace MHMovieDatabase.IMDB.Database;

public class ImdbDatabaseContext : MyDbContext<Movie>, IMovies
{
    public ImdbDatabaseContext(IDbConnectionDetails dbDetails) : base(dbDetails)
    { }

    public List<Movie> Movies() => Entities.ToList();

    public List<Movie> Slice(int startIndex, int count) => MovieRange(startIndex, count);
    
    public List<Movie> Page(int page, int wordLimit)
    {
        /*
         * I know this isn't best practice and there are performance issues
         * with this approach. However, since MySQL doesn't provide an
         * option to accurately retrieve the number of rows in a given table
         * without traversing through the whole table, I adhere to the lazy
         * implementation. Yes, I can rely on estimates that MySQL uses internally,
         * but that is for another assignment.
         */
        var index = (page - 1) * wordLimit;
        return MovieRange(index, wordLimit - 1);
    }

    public int Count() => Entities.Count();

    private List<Movie> MovieRange(int startIndex, int count)
    {
        /*
         * This approach seems to be the best in terms of performance
         * according to several sources on the internet.
         *
         * This can also be justified by the fact, that 'id' is a primary key and is
         * also an index, which speeds up lookup times by a great margin.
         * 
         * The following code translates into something like:
         *
         *      SELECT (row1, ..., rowN) from movies
         *      WHERE id >= index AND id >= max;
         *
         * The alternative approach is using Skip and Take methods of IQueryable
         * which translates into:
         *
         *      SELECT (row1, ..., rowN) from movies
         *      LIMIT 'count' OFFSET 'index'
         *
         * This is cost expensive as MySQL will traverse through the whole list
         * until reaching the index position. It takes no effort to imagine
         * the performance cost when dealing with huge amount of rows.
         *
         * For more info on the issue take a look at (he sums it up pretty well I think):
         *  https://use-the-index-luke.com/sql/partial-results/fetch-next-page
         */
        
        var index = startIndex + 1;
        var max = index + count;
        return Entities
            .Where(m => m.Id >= index && m.Id <= max)
            .ToList();
    }
}