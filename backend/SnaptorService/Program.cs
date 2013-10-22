using MutexManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnaptorService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!SingleInstance.Start()) 
            { 
                return; 
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                var applicationContext = new CustomApplicationContext();
                Application.Run(applicationContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Program terminated unexpectedly",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SingleInstance.Stop();
        }
    }
}
