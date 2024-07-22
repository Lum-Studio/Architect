using System.Collections.ObjectModel;

namespace Architect.Models;

public class ProjectFile
{
    public Guid Id { get; } = Guid.NewGuid();
    private IReadOnlyCollection<IUIElement>? _cachedReadOnlyElements;
    private readonly Dictionary<Guid, IUIElement> _uiElements = new();


    public void AddElement(IUIElement element)
    {
        _uiElements[element.Id] = element;
        _cachedReadOnlyElements = null;
    }

    public IReadOnlyCollection<IUIElement>? GetElements()
    {
        return _cachedReadOnlyElements ??= new ReadOnlyCollection<IUIElement>(_uiElements.Values.ToList());
    }

    public void DeleteElement(Guid elementId)
    {
        _uiElements.Remove(elementId);
        _cachedReadOnlyElements = null;
    }

    public void SetUIElements(IEnumerable<IUIElement> elements)
    {
        ArgumentNullException.ThrowIfNull(elements);
        _uiElements.Clear();
        foreach (var element in elements)
        {
            _uiElements[element.Id] = element;
        }
    }
}

