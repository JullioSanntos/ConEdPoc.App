using Microsoft.Maui.Graphics;

namespace ConEd.Views.Drawables;

public class HatchPatternDrawable : IDrawable {
    public Color StripeColor { get; set; } = Colors.White;
    public float StripeThickness { get; set; } = 2f;
    public float StripeSpacing { get; set; } = 5f;
    public void Draw(ICanvas canvas, RectF dirtyRect) {
        canvas.SaveState();
        canvas.ClipRectangle(dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height);
        canvas.StrokeColor = StripeColor;
        canvas.StrokeSize = StripeThickness;
        for (float offset = -dirtyRect.Height; offset < dirtyRect.Width + dirtyRect.Height; offset += StripeSpacing)
            canvas.DrawLine(dirtyRect.X + offset, dirtyRect.Bottom, dirtyRect.X + offset + dirtyRect.Height, dirtyRect.Y);
        canvas.RestoreState();
    }
}