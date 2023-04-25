using Microsoft.AspNetCore.Components;

namespace MHMoviesBlazorClient.Pages;

public partial class Index : ComponentBase
{
    private bool _showAutoView = false;
    private string _modeLabel = "Manual";

    private void SwitchMode()
    {
        _showAutoView = !_showAutoView;
        _modeLabel = _showAutoView ? "Auto" : "Manual";
    }
}