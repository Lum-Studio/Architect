using Architect.Models;
using System.Collections.ObjectModel;

namespace Architect.Services;

    public class ProjectService
    {
        private readonly Dictionary<Guid, Project> _projects = new();
        private IReadOnlyCollection<Project>? _cachedReadOnlyProjects;

        public event Action<IReadOnlyCollection<Project>>? OnProjectListUpdate;

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
                existingProject.UpdateFiles(updatedProject.GetProjectFiles());
                InvalidateCacheAndNotify();
            }
        }

        public void UpdateProjects(Dictionary<Guid, Project> projects)
        {
            ArgumentNullException.ThrowIfNull(projects);

            _projects.Clear();
            foreach (var project in projects.Values)
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
            OnProjectListUpdate?.Invoke(GetProjects());
        }
    }

