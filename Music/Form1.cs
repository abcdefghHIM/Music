using Music.Properties;
using MusicTool;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Music
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private const int VM_NCLBUTTONDOWN = 0XA1;
        private const int HTCAPTION = 2;
        public bool hasData = false;
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory("musicTool");
            /*
            Thread thread = new Thread(new ThreadStart(Th));
            thread.Start();
            UpData msg = JsonConvert.DeserializeObject<UpData>(WebTool.GetWebRequest("https://abcdefghHIM.github.io/Web/app/music/data.json"));
            try
            {
                thread.Abort();
            }
            catch
            { }
            if (!msg.Music.version.Equals(Program.version) && Program.version != -1)
            {
                new Message("Music", "正在更新 Music...", "下载更新中...", "Cancel", true, msg.Music.url, msg.Music.name).ShowDialog();
                hasData = true;
            }
            if (!msg.MusicControlLibrary.version.Equals(MusicControlLibrary.Program.version) && MusicControlLibrary.Program.version != -1)
            {
                new Message("Music", "正在更新 MusicControlLibrary...", "下载更新中...", "Cancel", true, msg.MusicControlLibrary.url, msg.MusicControlLibrary.name).ShowDialog();
                hasData = true;
            }
            if (!msg.MusicTool.version.Equals(MusicTool.Program.version) && MusicTool.Program.version != -1)
            {
                new Message("Music", "正在更新 MusicTool...", "下载更新中...", "Cancel", true, msg.MusicTool.url, msg.MusicTool.name).ShowDialog();
                hasData = true;
            }
            if (hasData)
            {
                throw new ArgumentNullException();
            }
            */
        }

        public Form1(bool update)
        {
            InitializeComponent();
        }

        private void Th()
        {
            new Message("Music", "正在连接 Music...", "检测更新中...", "Cancel", true).ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}
