using System.Drawing;
using SkiaSharp;

namespace Architect.Models;

public class Button : IUIElement
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public SKPoint Position { get; set; }
    public SKSize Size { get; set; }
    public List<IUIElement>? ChildElements { get; set; } = new();

    public void Draw(SKCanvas canvas)
    {
        
    }
}