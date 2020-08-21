using System;
using System.Windows.Forms;

namespace Aliance.NET
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FMenuPrin f = new FMenuPrin();
            f.ShowInTaskbar = true;
            Application.Run(f);
        }
    }
}
