using MHMovieDatabase.IMDB.Entities;

namespace MHMovieDatabase.IMDB.DataTransferObjects;

public class MoviePageResponse
{
    public int TotalPages { get; set; }
    public List<Movie>? Words { get; set; }
    public int PageNumber { get; set; }
}