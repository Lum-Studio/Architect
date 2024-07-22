using Fluxor;

[FeatureState]
public record ThemeState
{
    public bool IsDarkMode { get; init; } = true;

    public ThemeState() { }

    public ThemeState(bool isDarkMode)
    {
        IsDarkMode = isDarkMode;
    }
}
