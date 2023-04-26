using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Pages;

public partial class Index : ComponentBase
{
    private int ViewIndex = 0;
    private List<string> _labels = new()
    {
        "Page","Slice manual", "Slice auto"
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