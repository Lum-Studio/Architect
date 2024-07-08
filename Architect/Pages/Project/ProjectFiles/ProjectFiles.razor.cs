using Microsoft.AspNetCore.Components;

namespace Architect.Pages;

public partial class ProjectFiles
{
    [Parameter] public Guid ProjectId { get; set; }
}