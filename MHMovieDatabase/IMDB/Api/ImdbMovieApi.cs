using MHMovieDatabase.IMDB.Database;
using MHMovieDatabase.IMDB.DataTransferObjects;
using MHMovieDatabase.IMDB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MHMovieDatabase.IMDB.Api;

[ApiController,Route("/movies")]
public class ImdbMovieApi : Controller
{
    private readonly IMovies _dbContext;

    public ImdbMovieApi(IMovies dbContext) => _dbContext = dbContext;

    [HttpGet,Route("")]
    public List<Movie> All() => _dbContext.Movies();

    [HttpGet,Route("slice")]
    public List<Movie> Slice(int start, int count) => _dbContext.Slice(start,count);

    [HttpGet,Route("page")]
    public List<Movie> Page(int pageNumber, int wordLimit)
    {
        return _dbContext.Page(pageNumber,wordLimit);
    }

    [HttpGet,Route("count")]
    public int Count() => _dbContext.Count();
}