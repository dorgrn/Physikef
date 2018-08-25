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
            FirebaseClient client = new FirebaseClientFactory().CreateClient();
            FirebaseAuthProvider provider = new ProvidersFactory().CreateAuthProvider();
            AuthenticationManager authManager = new AuthenticationManager(client, provider);
            DataAccessLayer dal = new DataAccessLayer(client);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(authManager, dal));
        }
    }
}
