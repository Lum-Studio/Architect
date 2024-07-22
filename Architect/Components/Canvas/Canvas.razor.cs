using Architect.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using SkiaSharp.Views.Blazor;

namespace Architect.Components;

public partial class Canvas : ComponentBase, IDisposable
{
    [Parameter] public IReadOnlyCollection<IUIElement> Elements { get; set; }

    private SKCanvasView _canvasRef;
    private float _scale = 1.0f;
    private float _translateX;
    private float _translateY;
    private bool _isDragging;
    private float _lastMouseX;
    private float _lastMouseY;

    void OnWheel(WheelEventArgs e)
    {
        float zoomFactor = 1.1f; 
        if (e.DeltaY > 0)
        {
            _scale /= zoomFactor;
        }
        else
        {
            _scale *= zoomFactor;
        }
        Invalidate();
    }

 void OnMouseDown(MouseEventArgs e)
    {
        _isDragging = true;
        _lastMouseX = (float)e.OffsetX;
        _lastMouseY = (float)e.OffsetY;
    }

  void OnMouseUp(MouseEventArgs e)
    {
        _isDragging = false;
    }

    void OnMouseMove(MouseEventArgs e)
    {
        if (_isDragging)
        {
            float deltaX = (float)e.OffsetX - _lastMouseX;
            float deltaY = (float)e.OffsetY - _lastMouseY;
            
            _translateX += deltaX;
            _translateY += deltaY;

            _lastMouseX = (float)e.OffsetX;
            _lastMouseY = (float)e.OffsetY;
            Invalidate();
        }
    }
    
    void OnMouseLeave()
    {
        _isDragging = false;
    }
    
  void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.AliceBlue);
        canvas.Translate(_translateX, _translateY);
        canvas.Scale(_scale);
        canvas.DrawText("Testing", new SKPoint { X = 5, Y = 5 }, new SKPaint
        {
            Color = SKColors.Black,
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            TextAlign = SKTextAlign.Center,
            TextSize = 24
        });
    }

    protected override void OnInitialized()
    {
        _canvasRef = new SKCanvasView();
        _canvasRef.OnPaintSurface += OnPaintSurface;
    }

    private void RenderSelectionBox(SKCanvas canvas)
    {

    }

    public void Dispose()
    {
        _canvasRef.Dispose();
        _canvasRef = null;
    }
    
   private void Invalidate()
    {
        if (_canvasRef != null) {
            _canvasRef.Invalidate();
        }
    }
}
