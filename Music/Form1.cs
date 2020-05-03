using Music.Properties;
using MusicTool;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Music
{
    public partial class Form1 : Form
    {
        public bool hasData = false;
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory("musicTool");
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
        }

        public Form1(bool update)
        {
            InitializeComponent();
        }

        private void Th()
        {
            new Message("Music", "正在连接 Music...", "检测更新中...", "Cancel", true).ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (hasData)
            {
                string name = Process.GetCurrentProcess().MainModule.FileName;
                File.Delete("musicTool/MusicControlLibrary.dll");
                File.Delete("musicTool/MusicTool.dll");
                File.Copy("musicTool/MusicControlLibrary.dll.data", "musicTool/MusicControlLibrary.dll");
                File.Copy("musicTool/MusicTool.dll.data", "musicTool/MusicTool.dll");
                File.Delete("musicTool/MusicControlLibrary.dll.data");
                File.Delete("musicTool/MusicTool.dll.data");
                File.Delete(name);
                File.Copy("musicTool/Music.exe.data", name);
            }
        }
    }
}
