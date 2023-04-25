using System.Net.Http.Json;
using MHMoviesBlazorClient.DataTransferObjects;
using MHMoviesBlazorClient.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace MHMoviesBlazorClient.Components.ImdbMovies;

public partial class ImdbManualPaginatedView : ComponentBase
{
    [Inject] private ImdbManualpaginatedFetch PaginatedFetch { get; set; } = null!;

    private string _loadText = "Loading";
    
    protected override async Task OnInitializedAsync()
    {
        await PaginatedFetch.Initialize();
        _showFetchButton = true;
    }

    private bool _showFetchButton = false;

    private async Task FetchMore(int count)
    {
        StartLoadState(count);
        await PaginatedFetch.FetchMovies(count);
        EndLoadState();
    }

    private void StartLoadState(int count)
    {
        _loadText = $"Loading {count} more movies for you";
        _showFetchButton = false;
    }

    private void EndLoadState()
    {
        _loadText = !PaginatedFetch.HasMore() ? "No more movies to load" : _loadText;
        _showFetchButton = true;
    }
}