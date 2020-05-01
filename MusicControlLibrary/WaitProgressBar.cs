using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusicControlLibrary
{
    public class WaitProgressBar : ProgressBar
    {
        [Bindable(true)]
        [IODescription("ProgressBarValueDescr")]
        public int Speed { get; set; }
        [Bindable(true)]
        [IODescription("ProgressBarValueDescr")]
        public Color BorderColor { get; set; }
        [Bindable(true)]
        [IODescription("ProgressBarValueDescr")]
        public bool _Style { get; set; }
        private int len = 0;
        public WaitProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_Style)
            {
                SolidBrush brush = new SolidBrush(ForeColor);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                e.Graphics.FillRectangle(new SolidBrush(BorderColor), 0, 0, bounds.Width, bounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(BackColor), 1, 1, bounds.Width - 2, bounds.Height - 2);
                bounds.Width = ((int)(bounds.Width * (((double)Value) / Maximum))) - 4;
                e.Graphics.FillRectangle(brush, 1 + len, 1, bounds.Width, bounds.Height - 2);
                bounds = new Rectangle(0, 0, Width, Height);
                e.Graphics.FillRectangle(new SolidBrush(BorderColor), 0, 0, 1, bounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(BorderColor), bounds.Width - 1, 0, 1, bounds.Height);
                len += Speed;
                if (len > Width - 2)
                {
                    len = -bounds.Width;
                }
            }
            else
            {
                SolidBrush brush = new SolidBrush(ForeColor);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                e.Graphics.FillRectangle(new SolidBrush(BorderColor), 0, 0, bounds.Width, bounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(BackColor), 1, 1, bounds.Width - 2, bounds.Height - 2);
                bounds.Width = ((int)(bounds.Width * (((double)Value) / Maximum))) - 2;
                e.Graphics.FillRectangle(brush, 1, 1, bounds.Width, bounds.Height - 2);
            }
        }
    }
}
