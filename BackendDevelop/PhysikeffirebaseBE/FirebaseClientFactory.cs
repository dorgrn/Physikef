using System.Threading.Tasks;
using Firebase.Database;
using PhysikeffirebaseBE.Interfaces;

namespace PhysikeffirebaseBE
{
    public class FirebaseClientFactory : IFirebaseClientFactory
    {
        private readonly string m_SecretKey = "j4Iqr9XyQ1p3Lpvp4fsx8WzjPLG19G0pFWg80CBE";
        private readonly string m_AppUri = "https://physikef-18062.firebaseio.com";

        public FirebaseClient CreateClient()
        {
            var firebaseClient = new FirebaseClient(
                m_AppUri,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(m_SecretKey)
                });

            return firebaseClient;
        }
    }
}
