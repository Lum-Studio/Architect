using System.Collections.ObjectModel;

namespace Architect.Models;

    public class Project
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = "New Project";
        public string Author { get; set; } = "Architect";
        public string Description { get; set; } = string.Empty;
        private readonly Dictionary<Guid, ProjectFile> _files = new();
        private IReadOnlyCollection<ProjectFile>? _cachedReadOnlyFiles;

        public void AddFile(ProjectFile file)
        {
            ArgumentNullException.ThrowIfNull(file, nameof(file));

            _files[file.Id] = file;
            InvalidateCache();
        }

        public IReadOnlyCollection<ProjectFile> GetProjectFiles()
        {
            return _cachedReadOnlyFiles ??= new ReadOnlyCollection<ProjectFile>(_files.Values.ToList());
        }

        public void DeleteFile(Guid id)
        {
            _files.Remove(id);
            InvalidateCache();
        }

        public void SetFiles(IEnumerable<ProjectFile> projectFiles)
        {
            ArgumentNullException.ThrowIfNull(projectFiles, nameof(projectFiles));

            _files.Clear();
            foreach (var file in projectFiles)
            {
                _files[file.Id] = file;
            }

            InvalidateCache();
        }

        private void InvalidateCache()
        {
            _cachedReadOnlyFiles = null;
        }
    }
