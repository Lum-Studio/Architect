using System.Drawing;
using Microsoft.AspNetCore.Components;

namespace Architect.Models;

public class Button : IUIElement {
    public Guid Id { get; set; } = Guid.NewGuid();
    public Point Position { get; set; }
    public Point Size { get; set; }
    public List<IUIElement>? ChildElements { get; set; } = new();

    public RenderFragment Render() => builder =>
    {
        
    };
}