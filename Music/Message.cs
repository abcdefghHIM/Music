using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music
{
    public partial class Message : Form
    {
        private string Url { get; set; }
        private string MName { get; set; }
        private SynchronizationContext mainThreadSynContext;

        public Message()
        {
            InitializeComponent();
        }

        public Message(string title, string mess1, string mess2, string butt, bool type, string url = "",string name="")
        {
            InitializeComponent();
            Text = title;
            label1.Text = mess1;
            label2.Text = mess2;
            button1.Text = butt;
            progressBar1._Style = type;
            Url = url;
            MName = name;
            mainThreadSynContext = SynchronizationContext.Current;
            if (!Url.Equals(""))
            {
                Thread thread = new Thread(new ThreadStart(Download));
                thread.Start();
            }
        }

        private void OnConnected(object state)
        {
            Close();
        }


        public void Download()
        {
            if (!Url.Equals(""))
            {
                Download download = new Download();
                download.HttpDownloadFile(Url, "musicTool/" + MName + ".data");
            }
            mainThreadSynContext.Post(new SendOrPostCallback(OnConnected), null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
