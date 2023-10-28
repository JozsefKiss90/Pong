using System;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Pong.GameObecjts;

public class Paddle
{
    public Rectangle Shape { get; }
    public double Speed { get; set; }

    public Paddle(int width, int height, int speed)
    {
        Shape = new Rectangle{Width = width, Height = height, Fill = Brushes.White};
        Speed = 300;
    }

    public void MoveUp(double deltaTime)
    {
        double newPosition = Canvas.GetTop(Shape) - Speed * deltaTime;
    
        if (newPosition < 0)
        {
            newPosition = 0;
        }

        Canvas.SetTop(Shape, newPosition);
    }

    public void MoveDown(double deltaTime)
    {
        double newPosition = Canvas.GetTop(Shape) + Speed * deltaTime;
        
        double limit = 370; 
        if (newPosition + Shape.Height > limit)
        {
            newPosition = limit - Shape.Height;
        }

        Canvas.SetTop(Shape, newPosition);
    }

}