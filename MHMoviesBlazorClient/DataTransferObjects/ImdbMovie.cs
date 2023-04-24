namespace MHMoviesBlazorClient.DataTransferObjects;

public class ImdbMovie
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int Length { get; set; }
    public string Title { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public int Popularity { get; set; }
    public string Awards { get; set; } = null!;
}