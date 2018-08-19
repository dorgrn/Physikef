using Firebase.Auth;
using PhysikeffirebaseBE.Interfaces;

namespace PhysikeffirebaseBE
{
    public class ProvidersFactory : IFirebaseAuthProviderFactory
    {
        private readonly string m_WebApiKey = "AIzaSyBFBeOgm4y1OWloiY_T6c9peg54e0GSbXM";
        public FirebaseAuthProvider CreateAuthProvider()
        {
            return new FirebaseAuthProvider(new FirebaseConfig(m_WebApiKey));
        }
    }
}
