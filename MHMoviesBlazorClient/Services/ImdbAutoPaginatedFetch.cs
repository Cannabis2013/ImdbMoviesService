using System.Net.Http.Json;
using MHMoviesBlazorClient.DataTransferObjects;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace MHMoviesBlazorClient.Services;

public class ImdbAutoPaginatedFetch
{
    private readonly HttpClient Client;

    private int _moviesCount = 0;
    private int _index = -1;
    
    private List<ImdbMovie> CachedMovies { get; set; } = new();
    
    private const string EndpointUri = "https://localhost:6083/movies/paginated";
    private const string CountUri = "https://localhost:6083/movies/count";

    public ImdbAutoPaginatedFetch(HttpClient client)
    {
        Client = client;
    }
    
    public async Task Initialize()
    {
        _moviesCount = await Client.GetFromJsonAsync<int>(CountUri);
    }
    
    public async ValueTask<ItemsProviderResult<ImdbMovie>> LoadMovies(ItemsProviderRequest request)
    {
        var startIndex = request.StartIndex;
        var count = request.Count;
        if (startIndex > _index)
        {
            if (_index == -1)
                _index = 0;
            var uri = EndpointUri + $"?start={_index}&count={count}";
            _index += count + 1;
            var movies = await Client.GetFromJsonAsync<List<ImdbMovie>>(uri) ?? new ();
            CachedMovies.AddRange(movies);
            return new(movies,_moviesCount);
        }
        else
        {
            var movies = CachedMovies
                .Skip(startIndex).Take(count);
            return new(movies, _moviesCount);
        }
    }
}