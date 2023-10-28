using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pong
{
    public partial class MainWindow : Window
    {
        private Game Pong;
        private Canvas GameCanvas;
        private Grid GameGrid;
        private HashSet<Key> pressedKeys = new HashSet<Key>();
        private Stopwatch stopwatch = new Stopwatch();
    
        public MainWindow()
        {
            InitializeComponent();
            GameGrid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            GameCanvas = new Canvas
            {
                Background = Brushes.Black,
                Height = 360,
                Width = 580
            };
            
            GameGrid.Children.Add(GameCanvas); 
            Content = GameGrid;
            Pong = new Game(GameCanvas); 
            
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) }; 
            timer.Tick += GameLoop;
            timer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            double deltaTime = stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();

            if (pressedKeys.Contains(Key.W))
            {
                Pong.MovePlayerPaddleUp(deltaTime);
            }
            if (pressedKeys.Contains(Key.S))
            {
                Pong.MovePlayerPaddleDown(deltaTime);
            }
            Pong.Update();
            Pong.MoveAIPaddle(deltaTime);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {   
            pressedKeys.Add(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.Key);
        }

    }

}