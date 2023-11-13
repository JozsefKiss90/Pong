using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Pong.GameObecjts;

public class Ball
{
    public Ellipse Shape { get; }
    public double Speed { get; set; }
    public Vector Direction { get; set; }
    public Ball(double diameter)
    {
        Shape = new Ellipse
        {
            Width = diameter,
            Height = diameter,
            Fill = Brushes.White
        };
        
        Speed = 5;
        Direction = new Vector(-1, 1); 
    }
    
    public void UpdatePosition(double canvasHeight)
    {
        double newX = Canvas.GetLeft(Shape) + Direction.X * Speed;
        double newY = Canvas.GetTop(Shape) + Direction.Y * Speed;

        if (newY < 0)
        {
            newY = 0;
            Direction = new Vector(Direction.X, -Direction.Y);
        }

        if (newY + Shape.Height > canvasHeight)
        {
            newY = canvasHeight - Shape.Height;
            Direction = new Vector(Direction.X, -Direction.Y);
        }

        Canvas.SetLeft(Shape, newX);
        Canvas.SetTop(Shape, newY);
    }

    public bool IsCollidingWith(Paddle paddle)
    {
        Rect ballRect = new Rect(Canvas.GetLeft(Shape), Canvas.GetTop(Shape), Shape.Width, Shape.Height);
        Rect paddleRect = new Rect(Canvas.GetLeft(paddle.Shape), Canvas.GetTop(paddle.Shape), paddle.Shape.Width, paddle.Shape.Height);
        return ballRect.IntersectsWith(paddleRect);
    }
    
    public void BounceOffPaddle()
    {
        Direction = new Vector(-Direction.X, Direction.Y);
    }

    public bool IncrementScore(Game game)
    {
        Rect ballRect = new Rect(Canvas.GetLeft(Shape), Canvas.GetTop(Shape), Shape.Width, Shape.Height);
        if (ballRect.Left < 0)
        {
            game.PlayerScore += 1;
            return true;
        }
        if (ballRect.Left > 580)
        {
            game.AIScore += 1;
            return true;
        }

        return false;
    }
}