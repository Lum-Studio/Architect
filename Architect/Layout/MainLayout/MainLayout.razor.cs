using Architect.Services;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Architect.Layout;

    public partial class MainLayout
    {
        [Inject] private IState<ThemeState> ThemeState { get; set; }
        [Inject] private ThemeService ThemeService {get; set;}
    }

