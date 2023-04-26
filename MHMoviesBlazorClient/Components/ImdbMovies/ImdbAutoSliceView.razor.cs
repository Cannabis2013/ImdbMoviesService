using System.Net.Http.Json;
using MHMoviesBlazorClient.DataTransferObjects;
using MHMoviesBlazorClient.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace MHMoviesBlazorClient.Components.ImdbMovies;

public partial class ImdbAutoSliceView : ComponentBase
{
    [Inject] private ImdbAutoSlicedFetch ImdbAutoSlicedFetch { get; set; } = null!;
    
    protected override async Task OnInitializedAsync() => await ImdbAutoSlicedFetch.Initialize();
}