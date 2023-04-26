using MHMoviesBlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Components.ImdbMovies;

public partial class ImdbPaginatedView : ComponentBase
{
    [Inject] private ImdbPageFetch PaginatedFetch { get; set; } = null!;
    
    protected override async Task OnInitializedAsync() => await PaginatedFetch.Initialize();
}