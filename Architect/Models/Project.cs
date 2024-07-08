namespace Architect.Models;

public class Project
{
    public Guid Id = Guid.NewGuid();
    public string Name = "New Project";
    public string Author = "Architect";
    public string Description = string.Empty;
    private readonly Dictionary<Guid, ProjectFile> _files = new();

    public void AddFile(ProjectFile file)
    {
        ArgumentNullException.ThrowIfNull(file);
        _files[file.Id] = file;
    }

    public IReadOnlyCollection<ProjectFile> GetProjectFiles()
    {
        return _files.Values.ToList().AsReadOnly();
    }

    public void DeleteFile(Guid id)
    {
        _files.Remove(id);
    }

    public void UpdateFiles(IEnumerable<ProjectFile> projectFiles)
    {
        ArgumentNullException.ThrowIfNull(projectFiles);
        _files.Clear();
        foreach (var file in projectFiles)
        {
            _files[file.Id] = file;
        }
    }
}

