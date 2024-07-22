using Architect.Services;
using Microsoft.AspNetCore.Components;

namespace Architect.Pages;

public partial class ProjectFiles
{
    [Parameter] public Guid ProjectId { get; set; }
    [Inject] ProjectService ProjectService {get; set;}
    Models.Project Project {get; set;}

    protected override void OnInitialized()
    {
        Project = ProjectService.GetProjectById(ProjectId);
        base.OnInitialized();
    }
}