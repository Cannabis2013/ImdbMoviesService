using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Pages;

public partial class Index : ComponentBase
{
    private int ViewIndex = 0;
    private List<string> _labels = new()
    {
        "Paginated view",
        "Sliced view with buttons", 
        "Sliced view with no buttons (Not working 100%)"
    };

    private string Label() => _labels.ElementAt(ViewIndex);

    private void SwitchMode()
    {
        if (ViewIndex >= 2)
            ViewIndex = 0;
        else
            ViewIndex++;
    }
    
    
}