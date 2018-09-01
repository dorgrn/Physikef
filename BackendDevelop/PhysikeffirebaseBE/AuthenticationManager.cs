using System.Linq;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using PhysikeffirebaseBE.Interfaces;

namespace PhysikeffirebaseBE
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly FirebaseClient m_FirebaseClient;
        private readonly FirebaseAuthProvider m_FirebaseProvider;

        public AuthenticationManager()
        {
            m_FirebaseClient = new FirebaseClientFactory().CreateClient();
            m_FirebaseProvider = new ProvidersFactory().CreateAuthProvider();
        }

        public async Task<bool> RegisterAsync(string email, string userDisplayName, string password,string userID, string userType)
        {
            var result = await m_FirebaseProvider.CreateUserWithEmailAndPasswordAsync(email, password, userDisplayName);

            if (result.User != null)
            {
                var registeredUser = new User()
                {
                    displayname = result.User.DisplayName,
                    email = result.User.Email,
                    userid = userID,
                    usertype = userType
                };

                await m_FirebaseClient.Child("users").PostAsync(registeredUser);
                return true;
            }

            return false;
        }

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var result = await m_FirebaseProvider.SignInWithEmailAndPasswordAsync(email, password);

            if (result.User != null)
            {
                var allUsers = await m_FirebaseClient.Child("users").OnceAsync<User>();

                return new LoginResult()
                {
                    IsLoggedIn = true,
                    LoggedInUser = allUsers.First(user => user.Object.email == email).Object
                };
            }

            return new LoginResult()
            {
                IsLoggedIn = false
            };
        }

        public async Task ResetPassword(string email)
        {
            await m_FirebaseProvider.SendPasswordResetEmailAsync(email);
        }
    }
}
