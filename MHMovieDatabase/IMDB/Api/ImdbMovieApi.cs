using MHMovieDatabase.IMDB.Database;
using MHMovieDatabase.IMDB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHMovieDatabase.IMDB.Api;

[ApiController,Route("/movies")]
public class ImdbMovieApi : Controller
{
    private readonly ImdbDatabaseContext _dbContext;

    public ImdbMovieApi(ImdbDatabaseContext dbContext) => _dbContext = dbContext;

    [HttpGet,Route("")]
    public List<Movie> All() => _dbContext.Movies();

    [HttpGet,Route("paginated")]
    public List<Movie> Page(int start, int count) => _dbContext.Movies(start,count);

    [HttpGet,Route("count")]
    public int Count() => _dbContext.Count();
}