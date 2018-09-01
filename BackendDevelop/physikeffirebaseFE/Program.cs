using System;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Auth;
using PhysikeffirebaseBE;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
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
            Application.Run(new LoginForm());
        }
    }
}
