using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTS.Tool_Khao_Sat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// NTXUAN
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            // adb
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fForm());
        }
    }
}
