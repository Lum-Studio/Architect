namespace Architect.Models;

public class ProjectFile
{
    public Guid Id = Guid.NewGuid();
    public List<IUIElement>? UIElements = new();
}