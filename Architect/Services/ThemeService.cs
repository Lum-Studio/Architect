using Architect.Store;
using Fluxor;
using MudBlazor;
using MudBlazor.Utilities;

namespace Architect.Services;

public class ThemeService
{
    private readonly IDispatcher _dispatcher;
    public readonly MudTheme DefaultTheme;
    public ThemeService(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
        DefaultTheme = new MudTheme
        {
            Palette = new PaletteLight
            {
                AppbarBackground = Colors.Shades.White,
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                Primary = Colors.Shades.Black,
                Background = Colors.Shades.White,
                Secondary = Colors.Shades.White,

            },
            PaletteDark = new PaletteDark
            {
                AppbarBackground = new MudColor("#1b1b1f"),
                AppbarText = Colors.Shades.White,
                Primary = Colors.Shades.White,
                Background = new MudColor("#1b1b1f"),
                TextPrimary = Colors.Shades.White,
                Secondary = Colors.Shades.Black,
                
            }
        };
    }

    public void ToggleTheme()
    {
        _dispatcher.Dispatch(new ToggleThemeAction());
    }
}
