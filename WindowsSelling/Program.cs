using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSelling.Models;

namespace WindowsSelling
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {            
            if (Security.CheckSerialKey())
            {
                Security.CheckSerialKey();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MDI());
            }
            else
            {
                frmActivationWizard ActivationWizard = new frmActivationWizard();
                ActivationWizard.ShowDialog();
            }
        }
    }
}
