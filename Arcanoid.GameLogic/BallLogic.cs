using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcanoid.Contracts;

namespace Arcanoid.GameLogic
{
    /// <summary>
    /// Логика мячей в игре, отвечающая за движение, отрисовку и столкновения.
    /// </summary>
    public class BallLogic
    {
        /// <summary>
        /// Получает мяч, связанный с логикой.
        /// </summary>
        public Ball Ball { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса BallLogic с заданным мячом.
        /// </summary>
        /// <param name="ball">Мяч, который будет управляться логикой.</param>
        public BallLogic(Ball ball)
        {
            Ball = ball;
        }

        /// <summary>
        /// Перемещает мяч по его текущей скорости.
        /// </summary>
        public void Move()
        {
            Ball.X += Ball.SpeedX;
            Ball.Y += Ball.SpeedY;
        }

        /// <summary>
        /// Отрисовывает мяч на заданном графическом контексте.
        /// </summary>
        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Ball.Color), Ball.X - Ball.Radius, Ball.Y - Ball.Radius, Ball.Radius * 2, Ball.Radius * 2);
        }

        /// <summary>
        /// Проверяет и обрабатывает столкновения мяча со стенами игрового поля.
        /// </summary>
        public void BounceOffWalls(int formWidth, int formHeight)
        {
            if (Ball.X - Ball.Radius <= 0 || Ball.X + Ball.Radius >= formWidth)
            {
                Ball.SpeedX = -Ball.SpeedX;
            }

            if (Ball.Y - Ball.Radius <= 0)
            {
                Ball.SpeedY = -Ball.SpeedY;
            }
        }

        /// <summary>
        /// Проверяет, столкнулся ли мяч с платформой.
        /// </summary>
        public bool HitPlatform(PlatformLogic platformLogic)
        {
            Rectangle ballRect = new Rectangle(Ball.X - Ball.Radius, Ball.Y - Ball.Radius, Ball.Radius * 2, Ball.Radius * 2);
            return ballRect.IntersectsWith(platformLogic.GetRectangle());
        }
    }
}
