using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicControlLibrary
{
    public class Program
    {
#if DEBUG
#warning 现在是Ddbug状态
        public const int version = -1;
#else
        public const int version = 1;
#endif
    }
}
