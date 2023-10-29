using System.Windows;
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
    public TextBlock ScoreText { get; private set; }

    public int PlayerScore;
    public int AIScore;
    
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
        
        PlayerScore = 0;
        AIScore = 0;
        
        ScoreText = new TextBlock
        {
            Foreground = Brushes.White,
            FontSize = 24,
            TextAlignment = TextAlignment.Center,
            Width = GameCanvas.Width
        };
        UpdateScoreDisplay();
        GameCanvas.Children.Add(ScoreText);
        Canvas.SetTop(ScoreText, 5);
        Canvas.SetLeft(ScoreText, 0);
    }

    public void Update()
    {
        Ball.UpdatePosition(GameCanvas.Height);
        bool isScore = Ball.IncrementScore(this);
        if (isScore)
        {   
            UpdateScoreDisplay();
            //restart the game while keeping the current score
            Canvas.SetLeft(PlayerPaddle.Shape, 10);
            Canvas.SetTop(PlayerPaddle.Shape, 170);
        
            Canvas.SetLeft(AIPaddle.Shape, 560);
            Canvas.SetTop(AIPaddle.Shape, 170);
            
            Canvas.SetLeft(Ball.Shape, 295);
            Canvas.SetTop(Ball.Shape, 195);
        }
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
        double difference = Canvas.GetTop(Ball.Shape) - Canvas.GetTop(AIPaddle.Shape);

        double deadZone = 10; 
        
        if (difference > deadZone)
        {
            AIPaddle.MoveDown(deltaTime);
        }
        else if (difference < -deadZone)
        {
            AIPaddle.MoveUp(deltaTime);
        }
    }
    
    public void UpdateScoreDisplay()
    {
        ScoreText.Text = $"{PlayerScore} - {AIScore}";
    }


}