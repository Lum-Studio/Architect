using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Architect.Layout;

    public partial class MainLayout
    {
        [Inject] private IState<ThemeState> ThemeState { get; set; }
    }

