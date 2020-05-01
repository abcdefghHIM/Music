using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{

    public class UpData
    {
        public Music Music { get; set; }
        public Musiccontrollibrary MusicControlLibrary { get; set; }
        public Musictool MusicTool { get; set; }
    }

    public class Music
    {
        public string name { get; set; }
        public string url { get; set; }
        public int version { get; set; }
    }

    public class Musiccontrollibrary
    {
        public string name { get; set; }
        public string url { get; set; }
        public int version { get; set; }
    }

    public class Musictool
    {
        public string name { get; set; }
        public string url { get; set; }
        public int version { get; set; }
    }

}
