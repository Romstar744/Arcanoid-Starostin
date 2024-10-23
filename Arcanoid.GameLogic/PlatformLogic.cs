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
    /// Логика платформы в игре, отвечающая за управление движением и отрисовку платформы.
    /// </summary>
    public class PlatformLogic
    {
        private Platform platform;

        public PlatformLogic(Platform platform)
        {
            this.platform = platform;
        }

        public void MoveLeft()
        {
            if (platform.X > 0)
            {
                platform.X -= platform.Speed;
            }
        }

        public void MoveRight(int formWidth)
        {
            if (platform.X + platform.Width < formWidth)
            {
                platform.X += platform.Speed;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(platform.Color), platform.X, platform.Y, platform.Width, platform.Height);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(platform.X, platform.Y, platform.Width, platform.Height);
        }
    }
}
