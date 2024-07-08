using Architect.Models;
using Architect.Services;
using Microsoft.AspNetCore.Components;

namespace Architect.Components;

public partial class ProjectList : IDisposable  {
    [Inject] ProjectService ProjectService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    IReadOnlyCollection<Project> _projects { get; set; }
    protected override void OnInitialized()
    {
        _projects = ProjectService.GetProjects();
        ProjectService.OnProjectListUpdate += OnProjectListUpdate;
        base.OnInitialized();
    }

    void NavigateToProjectFiles(Guid projectId)
    {
        NavigationManager.NavigateTo($"/project/{projectId}/files");
    }
    
    void OnProjectListUpdate(IReadOnlyCollection<Project> projects)
    {
        _projects = projects;
        InvokeAsync(StateHasChanged);
    }

    public void Dispose() => ProjectService.OnProjectListUpdate -= OnProjectListUpdate;
    
}

