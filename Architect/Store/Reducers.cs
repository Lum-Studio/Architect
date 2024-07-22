using Architect.Models;
using Architect.Store;
using Fluxor;

public static class Reducers
{
    [ReducerMethod(typeof(ToggleThemeAction))]
    public static ThemeState ReduceToggleThemeAction(ThemeState state) => state with { IsDarkMode = !state.IsDarkMode};

}