using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Components.Pagination;

public partial class PaginationNavigationBar : ComponentBase
{
    [Parameter] public int ButtonsCount { get; set; } = 5;
    [Parameter] public int PageCount { get; set; }= 0;

    [Parameter]
    public EventCallback<int> PageRequestHandler { get; set; } = new();

    private async Task HandlePageRequest(int pageNumber) => await PageRequestHandler.InvokeAsync(pageNumber);

    private int _baseIndex = 1;
    private void ShiftBeginning() => _baseIndex = 1;

    private void ShiftEnd() => _baseIndex = PageCount - ButtonsCount;

    private void ShiftLeft()
    {
        if (_baseIndex > 0)
            _baseIndex--;
    }

    private void ShiftRight()
    {
        var lastValidIndex = PageCount - ButtonsCount;
        if(_baseIndex < lastValidIndex)
            _baseIndex++;
    }
}