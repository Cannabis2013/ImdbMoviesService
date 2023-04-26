using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Components.Pagination;

public partial class PaginationNavigationBar : ComponentBase
{
    [Parameter] public int ButtonsCount { get; set; } = 5;
    [Parameter] public int PageCount { get; set; }= 0;

    [Parameter]
    public EventCallback<int> PageRequestHandler { get; set; } = new();

    private int _baseIndex = 1;
    private int _currentPageNumber = 1;
    
    private async Task HandlePageRequest(int pageNumber)
    {
        _currentPageNumber = pageNumber;
        await PageRequestHandler.InvokeAsync(pageNumber);
    }

    private string SelectedCss(int pageNumberId) => _currentPageNumber == pageNumberId ? "page-btn-sel" : "";
    
    private void ShiftBeginning() => _baseIndex = 1;

    private void ShiftEnd() => _baseIndex = PageCount - ButtonsCount;

    private void ShiftLeft()
    {
        if (_baseIndex > 1)
            _baseIndex--;
    }

    private void ShiftRight()
    {
        var lastValidIndex = PageCount - ButtonsCount;
        if(_baseIndex < lastValidIndex)
            _baseIndex++;
    }
}