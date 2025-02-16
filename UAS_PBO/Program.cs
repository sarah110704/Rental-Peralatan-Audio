using System;
using System.Windows.Forms;
using UAS_PBO.view;


namespace UAS_PBO
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
            Application.Run(new FormCustomerDashboard());
        }
    }
}
