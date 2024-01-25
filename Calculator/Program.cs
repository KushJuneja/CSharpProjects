//////////////////////////////////////////////////////////////////////////
/// Kush Juneja
/// TINFO-200 CW Programming
/// Lcalc - the GUI calculator assignment
/// 
/////////////////////////////////////////////////////////////////////////
/// Change History
/// Date        Developer           Description
/// 2024-01-15  Kush Juneja         Initial creation of program, app, and this file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    // The starting point for the application / GUI components
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
            Application.Run(new Form1());
        }
    }
}
