using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class GameManager
{
    public Ball Ball;
    public Paddle Paddle;
    public List<Block> Blocks;
    public List<PowerUp> PowerUps;
    public int Score = 0;
    public int HighScore;

    public GameManager()
    {
        Ball = new Ball(200, 300, 15, Brushes.Red);
        Paddle = new Paddle(150, 400, 100, 20, Brushes.Blue);
        Blocks = new List<Block>();
        PowerUps = new List<PowerUp>();
        HighScore = FileManager.LoadHighScore();

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 8; j++)
                Blocks.Add(new Block(60 * j, 30 * i + 50, 58, 28, Brushes.Green));
    }

    public void Update(Keys key)
    {
        Ball.Update();

        if (key == Keys.Left) Paddle.MoveLeft();
        if (key == Keys.Right) Paddle.MoveRight();

        if (Ball.Rect.Left <= 0 || Ball.Rect.Right >= 500) Ball.BounceX();
        if (Ball.Rect.Top <= 0) Ball.BounceY();
        if (Ball.Rect.IntersectsWith(Paddle.Rect)) Ball.BounceY();

        foreach (var block in Blocks)
        {
            if (!block.Destroyed && Ball.Rect.IntersectsWith(block.Rect))
            {
                block.Destroyed = true;
                Ball.BounceY();
                Score += 10;
                break;
            }
        }

        if (Ball.Rect.Bottom >= 500)
        {
            if (Score > HighScore)
            {
                HighScore = Score;
                FileManager.SaveHighScore(HighScore);
            }
            Reset();
        }
    }

    public void Draw(Graphics g)
    {
        Ball.Draw(g);
        Paddle.Draw(g);
        foreach (var block in Blocks)
            if (!block.Destroyed) block.Draw(g);
    }

    private void Reset()
    {
        Ball.Rect.X = 200;
        Ball.Rect.Y = 300;
        Score = 0;
        foreach (var block in Blocks)
            block.Destroyed = false;
    }
}
