﻿using System.Threading.Tasks;

public interface IAuthenticationManager
{
    Task RegisterAsync(string email, string userDisplayName, string password, string userID, string userType);
    Task<LoginResult> LoginAsync(string email, string password);
    Task AnonymousLoginAsync();
    Task ResetPasswordAsync(string email);
    string GetCurrentUserEmail();
}