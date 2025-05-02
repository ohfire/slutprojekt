using System.Drawing;

public class Ball : GameObject
{
    public int Dx = 4;
    public int Dy = -4;

    public Ball(int x, int y, int size, Brush color) : base(x, y, size, size, color) { }

    public override void Update()
    {
        Rect.X += Dx;
        Rect.Y += Dy;
    }

    public void BounceX() => Dx = -Dx;
    public void BounceY() => Dy = -Dy;
}
