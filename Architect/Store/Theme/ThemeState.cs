using Fluxor;

[FeatureState]
public class ThemeState
{
    public bool IsDarkMode { get; private set; }

    public ThemeState()
    {
        IsDarkMode = true;
    }

    public ThemeState(bool isDarkMode)
    {
        IsDarkMode = isDarkMode;
    }
}