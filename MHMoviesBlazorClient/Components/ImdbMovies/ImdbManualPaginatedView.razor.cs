using System.Net.Http.Json;
using MHMoviesBlazorClient.DataTransferObjects;
using MHMoviesBlazorClient.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace MHMoviesBlazorClient.Components.ImdbMovies;

public partial class ImdbManualPaginatedView : ComponentBase
{
    [Inject] private ImdbManualpaginatedFetch PaginatedFetch { get; set; } = null!;

    private Virtualize<ImdbMovie> _virtualizeComponent;
    
    protected override async Task OnInitializedAsync()
    {
        await PaginatedFetch.Initialize();
        _showFetchButton = true;
    }

    private bool _showFetchButton = false;

    private async Task FetchMore(int count)
    {
        _showFetchButton = false;
        await PaginatedFetch.FetchMore(count);
        _showFetchButton = true;
    }
}