using MHMovieDatabase.IMDB.Database;
using Microsoft.AspNetCore.Mvc;

namespace MHMovieDatabase.IMDB.Api;

[ApiController,Route("/movies")]
public class ImdbMovieApi : Controller
{
    private readonly ImdbDatabaseContext _dbContext;

    public ImdbMovieApi(ImdbDatabaseContext dbContext) => _dbContext = dbContext;

    [HttpGet,Route("movies")]
    public JsonResult All()
    {
        var movies = _dbContext.Movies();
        return new(movies);
    }

    [HttpGet,Route("Paginated")]
    public JsonResult AllPaginated(int start, int count)
    {
        var movies = _dbContext.Movies(start,count);
        return new(movies);
    }
}