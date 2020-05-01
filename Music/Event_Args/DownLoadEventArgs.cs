using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Event_Args
{
    public class DownLoadEventArgs:EventArgs
    {
        public DownLoadEventArgs(long size,long now)
        {
            Size = size;
            Now = now;
        }

        public long Size { get; }
        public long Now { get; }
    }
}
