using Architect.Services;
using Fluxor;
using MudBlazor;
using Microsoft.AspNetCore.Components;

namespace Architect.Components;

public partial class NavHeader
{
    [Inject] private ThemeService ThemeService { get; set; }
    [Inject] private IState<ThemeState> ThemeState { get; set; }

    private string ButtonIcon =>
        ThemeState.Value.IsDarkMode ? Icons.Material.Filled.DarkMode : Icons.Material.Filled.LightMode;

    void OnClick()
    {
        ThemeService.ToggleTheme();
    }
}
