using System.Drawing;
using Microsoft.AspNetCore.Components;

namespace Architect.Models;

public interface IUIElement
{
    public Guid Id { get; private protected set; }
    public Point Position { get; set; }
    public Point Size { get; set; }
    public List<IUIElement>? ChildElements { get; set; }
    public RenderFragment Render();
    public void OnPropertyValueChange()
    {
        this.Render();
    }
}