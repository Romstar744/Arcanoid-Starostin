using System;
using Arcanoid.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arcanoid.GameLogic;
using test_arcanoid;

namespace Arcanoid
{
    public partial class Form1 : DoubleBufferedForm
    {
        BallLogic ballLogic;
        PlatformLogic platformLogic;
        List<BlockLogic> blockLogics;
        Timer gameTimer;

        int score = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            Ball ball = new Ball { X = 400, Y = 250, Radius = 10, SpeedX = 5, SpeedY = 5, Color = Color.Aquamarine };
            Platform platform = new Platform { X = 400, Y = this.ClientSize.Height - 50, Width = 100, Height = 20, Speed = 20, Color = Color.Yellow };

            ballLogic = new BallLogic(ball);
            platformLogic = new PlatformLogic(platform);
            blockLogics = new List<BlockLogic>();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Block block = new Block { X = 50 + i * 80, Y = 50 + j * 30, Width = 70, Height = 20, Color = Color.Violet, IsDestroyed = false };
                    blockLogics.Add(new BlockLogic(block));
                }
            }

            gameTimer = new Timer();
            gameTimer.Interval = 40;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            score = 0;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ballLogic.Move();
            ballLogic.BounceOffWalls(this.ClientSize.Width, this.ClientSize.Height);

            if (ballLogic.HitPlatform(platformLogic))
            {
                ballLogic.Ball.SpeedY = -ballLogic.Ball.SpeedY;
            }

            foreach (var blockLogic in blockLogics)
            {
                if (!blockLogic.Block.IsDestroyed && blockLogic.CheckCollision(ballLogic))
                {
                    ballLogic.Ball.SpeedY = -ballLogic.Ball.SpeedY;
                    score += 10;
                    labelScore.Text = "Score: " + score;
                }
            }

            if (ballLogic.Ball.Y > this.ClientSize.Height)
            {
                GameOver();
            }

            Invalidate();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            DialogResult result = MessageBox.Show("Игра окончена! Ваш счет: " + score + "\nХотите начать заново?", "Конец игры", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                InitializeGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ballLogic.Draw(g);
            platformLogic.Draw(g);

            foreach (var blockLogic in blockLogics)
            {
                blockLogic.Draw(g);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                platformLogic.MoveLeft();
            }

            if (e.KeyCode == Keys.Right)
            {
                platformLogic.MoveRight(this.ClientSize.Width);
            }
        }
    }
}
