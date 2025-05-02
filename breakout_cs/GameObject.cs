using System.Drawing;

public abstract class GameObject
{
    public Rectangle Rect;
    public Brush Color;

    public GameObject(int x, int y, int width, int height, Brush color)
    {
        Rect = new Rectangle(x, y, width, height);
        Color = color;
    }

    public virtual void Draw(Graphics g)
    {
        g.FillRectangle(Color, Rect);
    }

    public abstract void Update();
}
