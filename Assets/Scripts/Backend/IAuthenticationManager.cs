public interface IAuthenticationManager
{
    void Register(string email, string userDisplayName, string password,string userID, string userType);
    void Login(string email, string password);
    void AnonymousLogin();
    void Logout();
    void ResetPassword(string email);
}