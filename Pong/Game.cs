using System.Windows.Controls;
using System.Windows.Media;
using Pong.GameObecjts;

namespace Pong;

public class Game
{
    public Paddle PlayerPaddle { get; }
    public Paddle AIPaddle { get; }
    public Ball Ball { get; }
    private Canvas GameCanvas { get; }

    public Game(Canvas gameCanvas)
    {
        GameCanvas = gameCanvas;
        GameCanvas.Background = Brushes.Black;
        
        PlayerPaddle = new Paddle(10, 60, 5);
        AIPaddle = new Paddle(10, 60, 5);
        Ball = new Ball(10);
        
        GameCanvas.Children.Add(PlayerPaddle.Shape);
        GameCanvas.Children.Add(AIPaddle.Shape);
        GameCanvas.Children.Add(Ball.Shape);
        
        Canvas.SetLeft(PlayerPaddle.Shape, 10);
        Canvas.SetTop(PlayerPaddle.Shape, 170);
        
        Canvas.SetLeft(AIPaddle.Shape, 580);
        Canvas.SetTop(AIPaddle.Shape, 170);
        
        Canvas.SetLeft(Ball.Shape, 295);
        Canvas.SetTop(Ball.Shape, 195);
    }

    public void Update()
    {
        Ball.UpdatePosition();
    }
    
    public void MovePlayerPaddleUp(double deltaTime)
    {
        PlayerPaddle.MoveUp(deltaTime);
    }

    public void MovePlayerPaddleDown(double deltaTime)
    {
        PlayerPaddle.MoveDown(deltaTime);
    }
}