using System.Net.Http.Json;
using MHMoviesBlazorClient.DataTransferObjects;
using MHMoviesBlazorClient.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace MHMoviesBlazorClient.Components.ImdbMovies;

public partial class ImdbAutoPaginatedView : ComponentBase
{
    [Inject] private ImdbAutoPaginatedFetch ImdbAutoPaginatedFetch { get; set; } = null!;

    private Virtualize<ImdbMovie> _virtualizeComponent;
    
    protected override async Task OnInitializedAsync() => await ImdbAutoPaginatedFetch.Initialize();
}