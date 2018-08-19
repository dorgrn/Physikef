using Firebase.Database;

namespace PhysikeffirebaseBE.Interfaces
{
    public interface IFirebaseClientFactory
    {
        FirebaseClient CreateClient();
    }
}