using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music
{
    static class Program
    {
#if DEBUG
#warning 现在是Ddbug状态
        public const int version = -1;
#else
        public const int version = 1;
#endif
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool isRunning;
            new Mutex(false, Assembly.GetExecutingAssembly().FullName, out isRunning);
            if (!isRunning) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (args[0].ToLower().Equals("update"))
                {
                    Application.Run(new Form1(true));
                    return;
                }
                Application.Run(new Form1());
            }
            catch (ArgumentNullException)
            {
                Process process = new Process();
                process.StartInfo.FileName = Application.StartupPath + "/musicTool/MusicUpdateProgram.exe";
                process.StartInfo.Arguments = "update";
                process.Start();
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
