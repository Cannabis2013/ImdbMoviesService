using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHMovieDatabase.IMDB.Entities;

[Table("movies")]
public class Movie
{
    [Key]
    public int Id { get; set; }
    public int Year { get; set; }
    public int Length { get; set; }
    public string Title { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public int Popularity { get; set; }
    public string Awards { get; set; } = null!;
}