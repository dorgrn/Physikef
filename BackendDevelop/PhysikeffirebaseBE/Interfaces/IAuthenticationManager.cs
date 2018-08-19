using System.Threading.Tasks;

namespace PhysikeffirebaseBE.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> RegisterAsync(string email, string userDisplayName, string password,string userID, string userType);
        Task<LoginResult> LoginAsync(string email, string password);
        Task ResetPassword(string email);
    }
}
