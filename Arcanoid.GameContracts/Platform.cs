using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Contracts
{
    /// <summary>
    /// Представляет платформу в игре с её положением, размерами, скоростью и цветом.
    /// </summary>
    public class Platform
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public Color Color { get; set; }
    }
}
