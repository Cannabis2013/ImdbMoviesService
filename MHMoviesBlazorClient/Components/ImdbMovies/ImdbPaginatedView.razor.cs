using MHMoviesBlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Components.ImdbMovies;

public partial class ImdbPaginatedView : ComponentBase
{
    private int _buttonsCount = 5;
    
    [Inject] private ImdbPageFetch PaginatedFetch { get; set; } = null!;
    
    protected override async Task OnInitializedAsync() => await PaginatedFetch.Initialize();
}