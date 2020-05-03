using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicUpdateProgram
{
    class Program
    {
        public const int version = -1;

        static void Main(string[] args)
        {
            try
            {
                if (args[0].ToLower().Equals("update"))
                {
                    if (File.Exists(Application.StartupPath + "/../Music.exe"))
                        File.Delete(Application.StartupPath + "/../Music.exe");
                    File.Move(Application.StartupPath + "/Music.exe.data", Application.StartupPath + "/../Music.exe");
                    File.Move(Application.StartupPath + "/MusicControlLibrary.dll.data", Application.StartupPath + "/MusicControlLibrary.dll");
                    File.Move(Application.StartupPath + "/MusicTool.dll.data", Application.StartupPath + "/MusicTool.dll");
                    Process process = new Process();
                    process.StartInfo.FileName = Application.StartupPath + "/../Music.exe";
                    process.StartInfo.Arguments = "update";
                    process.Start();
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
                return;
            }
            Console.WriteLine("?");
            Console.ReadKey();
        }
    }
}
