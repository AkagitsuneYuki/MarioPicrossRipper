using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarioPicrossRipper
{
    internal static class Program
    {
        static public List<Picross> puzzles = new List<Picross>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
