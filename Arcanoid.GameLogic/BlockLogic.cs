using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Arcanoid.Contracts;

namespace Arcanoid.GameLogic
{
    /// <summary>
    /// Логика блоков в игре, отвечающая за отрисовку и проверку столкновений с мячом.
    /// </summary>
    public class BlockLogic
    {
        /// <summary>
        /// Получает блок, связанный с логикой.
        /// </summary>
        public Block Block { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса BlockLogic с заданным блоком.
        /// </summary>
        public BlockLogic(Block block)
        {
            Block = block;
        }

        // <summary>
        /// Отрисовывает блок на заданном графическом контексте.
        /// </summary>
        public void Draw(Graphics g)
        {
            if (!Block.IsDestroyed)
            {
                g.FillRectangle(new SolidBrush(Block.Color), Block.X, Block.Y, Block.Width, Block.Height);
            }
        }

        /// <summary>
        /// Проверяет, столкнулся ли блок с мячом.
        /// </summary>
        public bool CheckCollision(BallLogic ballLogic)
        {
            Rectangle blockRect = new Rectangle(Block.X, Block.Y, Block.Width, Block.Height);
            Rectangle ballRect = new Rectangle(ballLogic.Ball.X - ballLogic.Ball.Radius, ballLogic.Ball.Y - ballLogic.Ball.Radius, ballLogic.Ball.Radius * 2, ballLogic.Ball.Radius * 2);

            if (blockRect.IntersectsWith(ballRect))
            {
                Block.IsDestroyed = true;
                return true;
            }
            return false;
        }
    }
}
