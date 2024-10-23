using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Contracts
{
    /// <summary>
    /// Представляет мяч в игре с параметрами его положения, радиуса, скорости и цвета.
    /// </summary>
    public class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public Color Color { get; set; }
    }
}
