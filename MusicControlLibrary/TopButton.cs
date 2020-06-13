using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicControlLibrary
{
    public class TopButton : Button
    {
        public TopButton()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            FlatAppearance.MouseDownBackColor = Color.FromArgb(234, 65, 0);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 102, 45);
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;
            Text = "";
        }
    }
}
