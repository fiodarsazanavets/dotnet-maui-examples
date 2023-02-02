namespace MauiGraphicsDemo;

public class DrawableHelper : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Green;
        canvas.StrokeSize = 7;
        canvas.DrawEllipse(100, 100, 100, 100);
    }
}
