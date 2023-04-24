using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Services;

public class ImdbMovies
{
    [Inject] private HttpClient HttpClient { get; set; } = null!;
    
    
}