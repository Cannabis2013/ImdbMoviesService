using System.Net.Http.Json;
using MHMoviesBlazorClient.DataTransferObjects;

namespace MHMoviesBlazorClient.Services;

public class ImdbPageFetch
{
    private HttpClient Client { get; set; }

    public ImdbPageFetch(HttpClient client) => Client = client;

    private int _moviesCount;
    private const string PageEndpointUri = "https://localhost:6083/movies/page";
    private const string CountUri = "https://localhost:6083/movies/count";
    
    public List<ImdbMovie> CachedMovies { get; set; } = new();

    public int FetchedPages { get; set; } = 0;
    public int WordLimit { get; set; } = 10;

    public int PageCount()
    {
        if (WordLimit == 0)
            return -1;
        var count = _moviesCount / WordLimit;
        return count + 1;
    }

    public async Task Initialize()
    {
        _moviesCount = await Client.GetFromJsonAsync<int>(CountUri);
        await Fetch(1);
    }

    public async Task Fetch(int page)
    {
        var uri = PageEndpointUri + $"?pageNumber={page}&wordLimit={WordLimit}";
        CachedMovies = await Client.GetFromJsonAsync<List<ImdbMovie>>(uri) ?? new();
    }
}