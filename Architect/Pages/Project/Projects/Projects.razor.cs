using Architect.Services;
using Microsoft.AspNetCore.Components;
using Architect.Models;
using MudBlazor;

namespace Architect.Pages;

public partial class Projects : IDisposable {
    [Inject] ProjectService ProjectService {get;set;}
    [Inject] NavigationManager NavigationManager {get;set;}
    IReadOnlyCollection<Project> _projects {get; set;}
    string Search { get; set; }
    
    protected override void OnInitialized()
    {
        _projects  = ProjectService.GetProjects();
        ProjectService.OnProjectsUpdate += OnProjectsUpdate;
        AddTestProject();
    }
    
    void AddTestProject()
    {
        Project project = new () { Name="Test", Description = "This Is a Test" };
        ProjectService.AddProject(project);
        
    }
    
   void  OnProjectsUpdate(IReadOnlyCollection<Project> projects)
    {
        _projects = projects;
        InvokeAsync(StateHasChanged);
    }
    
    void NavigateToProjectFiles(object clickedElement)
    {
        Guid id = (Guid)(clickedElement as MudItem).Tag;
        NavigationManager.NavigateTo($"/projects/project/{id}/files");
    }
    
    public void Dispose()
    {
        ProjectService.OnProjectsUpdate -= OnProjectsUpdate;
        _projects = null;
    }
}