/**
 * Honeywell Total Connect 2.0 Windows Remake
 * Proof of Concept
 * 
 * (c) 2012-2014 atom0s [atom0s@live.com]
 */

namespace SecuritySystemTest
{
    using System;
    using System.Windows.Forms;

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
            Application.Run(new frmMain());
        }
    }
}
