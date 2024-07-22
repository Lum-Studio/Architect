using System.Drawing;
using SkiaSharp;

namespace Architect.Models;

public interface IUIElement
{
    public Guid Id { get; private protected set; }
    public SKPoint Position { get; set; }
    public SKSize Size { get; set; }
    public List<IUIElement>? ChildElements { get; set; }
    public void Draw(SKCanvas canvas);
}