using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Pong.GameObecjts;

public class Ball
{
    public Rectangle Shape { get; }
    public Vector Speed { get; set; }

    public Ball(double size)
    {
        Shape = new Rectangle { Width = size, Height = size, Fill = Brushes.White };
        Speed = new Vector(5, 5);
    }

    public void UpdatePosition()
    {
        Canvas.SetLeft(Shape, Canvas.GetLeft(Shape) + Speed.X);
        Canvas.SetTop(Shape, Canvas.GetTop(Shape) + Speed.Y);
    }
    
}