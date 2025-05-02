using System.Drawing;

public class Block : GameObject
{
    public bool Destroyed = false;

    public Block(int x, int y, int width, int height, Brush color) : base(x, y, width, height, color) { }

    public override void Update() { }
}
