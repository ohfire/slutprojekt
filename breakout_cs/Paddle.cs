using System.Drawing;

public class Paddle : GameObject
{
    public int Speed = 8;

    public Paddle(int x, int y, int width, int height, Brush color) : base(x, y, width, height, color) { }

    public override void Update() { }

    public void MoveLeft() => Rect.X -= Speed;
    public void MoveRight() => Rect.X += Speed;
}
