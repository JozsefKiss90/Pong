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
        PlayerPaddle = new Paddle(10, 60, 5);
        AIPaddle = new Paddle(10, 60, 5);
        Ball = new Ball(10);
        
        GameCanvas.Children.Add(PlayerPaddle.Shape);
        GameCanvas.Children.Add(AIPaddle.Shape);
        GameCanvas.Children.Add(Ball.Shape);
        
        Canvas.SetLeft(PlayerPaddle.Shape, 10);
        Canvas.SetTop(PlayerPaddle.Shape, 170);
        
        Canvas.SetLeft(AIPaddle.Shape, 560);
        Canvas.SetTop(AIPaddle.Shape, 170);
        
        Canvas.SetLeft(Ball.Shape, 295);
        Canvas.SetTop(Ball.Shape, 195);
    }

    public void Update()
    {
        Ball.UpdatePosition(GameCanvas.Height);
        if (Ball.IsCollidingWith(PlayerPaddle) || Ball.IsCollidingWith(AIPaddle))
        {
            Ball.BounceOffPaddle();
        }
    }
    
    public void MovePlayerPaddleUp(double deltaTime)
    {
        PlayerPaddle.MoveUp(deltaTime);
    }

    public void MovePlayerPaddleDown(double deltaTime)
    {
        PlayerPaddle.MoveDown(deltaTime);
    }
    
    public void MoveAIPaddle(double deltaTime)
    {
        // Determine the difference between the ball's Y position and the AIPaddle's Y position.
        double difference = Canvas.GetTop(Ball.Shape) - Canvas.GetTop(AIPaddle.Shape);

        double deadZone = 10;  // This means the AI paddle won't move unless the ball is 20 units above or below it.

        // Check if difference is greater than deadZone (meaning ball is significantly below the paddle)
        if (difference > deadZone)
        {
            // Move the AIPaddle down by a certain speed.
            AIPaddle.MoveDown(deltaTime);
        }
        // Otherwise, check if difference is less than negative deadZone (meaning ball is significantly above the paddle)
        else if (difference < -deadZone)
        {
            // Move the AIPaddle up by a certain speed.
            AIPaddle.MoveUp(deltaTime);
        }
        // If difference is within the deadZone, don't move the AIPaddle.
    }

}