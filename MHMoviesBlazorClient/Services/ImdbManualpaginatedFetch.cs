using System.Net.Http.Json;
using MHMoviesBlazorClient.DataTransferObjects;

namespace MHMoviesBlazorClient.Services;

public class ImdbManualpaginatedFetch
{
    private readonly HttpClient _client;

    public ImdbManualpaginatedFetch(HttpClient client) => _client = client;

    private const string EndpointUri = "https://localhost:6083/movies/slice";
    private const string CountUri = "https://localhost:6083/movies/count";

    private int _startIndex = 0;
    private const int Count = 50;
    
    private int _moviesCount = 0;
    
    public async Task Initialize()
    {
        _moviesCount = await _client.GetFromJsonAsync<int>(CountUri);
        await FetchMovies(50);
    }

    public List<ImdbMovie> CachedMovies { get; set; } = new();

    public bool HasMore() => _startIndex < _moviesCount;

    public async Task FetchMovies(int count)
    {
        if (_startIndex >= _moviesCount)
            return;
        var uri = EndpointUri + $"?start={_startIndex}&count={count}";
        _startIndex += count + 1;
        var movies = await _client.GetFromJsonAsync<List<ImdbMovie>>(uri) ?? new ();
        CachedMovies.AddRange(movies);
    }

}