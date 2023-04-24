using MHMovieDatabase.IMDB.Database;
using Microsoft.AspNetCore.Mvc;

namespace MHMovieDatabase.IMDB.Api;

[ApiController,Route("/movies")]
public class ImdbMovieApi : Controller
{
    private readonly ImdbDatabaseContext _dbContext;

    public ImdbMovieApi(ImdbDatabaseContext dbContext) => _dbContext = dbContext;

    [HttpGet,Route("")]
    public JsonResult All()
    {
        var movies = _dbContext.Movies();
        return new(movies);
    }

    [HttpGet,Route("paginated")]
    public JsonResult AllPaginated(int start, int count)
    {
        Thread.Sleep(1200);
        var movies = _dbContext.Movies(start,count);
        return new(movies);
    }

    [HttpGet,Route("count")]
    public int Count()
    {
        var count = _dbContext.Count();
        return count;
    }
}