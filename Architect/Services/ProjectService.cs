using Architect.Models;
using System.Collections.ObjectModel;
using MudBlazor;

namespace Architect.Services;

public interface IProjectService
{
    void AddProject(Project project);
    Project? GetProjectById(Guid id);
    IReadOnlyCollection<Project> GetProjects();
    void UpdateProject(Project updatedProject);
    void SetProjects(IReadOnlyCollection<Project> projects);
    void DeleteProject(Guid id);
    event Action<IReadOnlyCollection<Project>> OnProjectsUpdate;
}

public class ProjectService : IProjectService
{
    private readonly Dictionary<Guid, Project> _projects = new();
    private IReadOnlyCollection<Project>? _cachedReadOnlyProjects;

    public event Action<IReadOnlyCollection<Project>> OnProjectsUpdate;

    public void AddProject(Project project)
    {
        if (_projects.TryAdd(project.Id, project))
        {
            InvalidateCacheAndNotify();
        }
    }

    public Project? GetProjectById(Guid id)
    {
        _projects.TryGetValue(id, out var project);
        return project;
    }

    public IReadOnlyCollection<Project> GetProjects()
    {
        return _cachedReadOnlyProjects ??= new ReadOnlyCollection<Project>(_projects.Values.ToList());
    }

    public void UpdateProject(Project updatedProject)
    {
        if (_projects.TryGetValue(updatedProject.Id, out var existingProject))
        {
            existingProject.Author = updatedProject.Author;
            existingProject.Description = updatedProject.Description;
            existingProject.Name = updatedProject.Name;
            existingProject.SetFiles(updatedProject.GetProjectFiles());
            InvalidateCacheAndNotify();
        }
    }

    public void SetProjects(IReadOnlyCollection<Project> projects)
    {
        ArgumentNullException.ThrowIfNull(projects, nameof(projects));
        foreach (Project project in projects)
        {
            _projects[project.Id] = project;
        }

        InvalidateCacheAndNotify();
    }

    public void DeleteProject(Guid id)
    {
        if (_projects.Remove(id))
        {
            InvalidateCacheAndNotify();
        }
    }

    private void InvalidateCacheAndNotify()
    {
        _cachedReadOnlyProjects = null;
        OnProjectsUpdate.Invoke(GetProjects());
    }
}

