using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcanoid
{
    /// <summary>
    /// Формы с включенной двойной буферизацией для снижения мерцания при отрисовке.
    /// </summary>
    public class DoubleBufferedForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DoubleBufferedForm"/>.
        /// </summary>
        public DoubleBufferedForm()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }
    }
}
