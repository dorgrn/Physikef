using Firebase.Auth;

namespace PhysikeffirebaseBE.Interfaces
{
    public interface IFirebaseAuthProviderFactory
    {
        FirebaseAuthProvider CreateAuthProvider();
    }
}
