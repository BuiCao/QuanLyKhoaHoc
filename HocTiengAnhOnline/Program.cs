using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HocTiengAnhOnline
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // admin
            // Application.Run(new AdminHome());
            // sinh vien
            // Application.Run(new GiaoDienChinh());
            // login
            Application.Run(new Login());
        }
    }
}
