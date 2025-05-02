using System.Drawing;

public class PowerUp : GameObject
{
    public int Dy = 3;
    public string Type;

    public PowerUp(int x, int y, int size, Brush color, string type) : base(x, y, size, size, color)
    {
        Type = type;
    }

    public override void Update()
    {
        Rect.Y += Dy;
    }
}
