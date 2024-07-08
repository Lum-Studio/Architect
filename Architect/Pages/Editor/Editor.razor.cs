using Architect.Models;
using Architect.Services;
using Microsoft.AspNetCore.Components;

namespace Architect.Pages;

public partial class Editor
{
    [Parameter] public Guid ProjectId { get; set; }
    [Parameter] public Guid FileId { get; set; }
    [Inject] ProjectService ProjectService { get; set; }
    Models.Project? Project { get; set; }

    protected override void OnInitialized()
    {
        Project = ProjectService.GetProjectById(ProjectId);
        base.OnInitialized();
    }
}