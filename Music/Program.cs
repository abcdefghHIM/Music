using System;
using System.Collections.Generic;
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
        public const int version = 1;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isRunning;
            new Mutex(false, Assembly.GetExecutingAssembly().FullName, out isRunning);
            if (!isRunning) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch (ArgumentNullException)
            {

            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
