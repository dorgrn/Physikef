using System;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

public class AuthenticationManager : IAuthenticationManager
{
    public async Task RegisterAsync(string email, string userDisplayName, string password,string userID, string userType)
    {
        var auth = FirebaseAuth.DefaultInstance;
        await auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                throw new Exception("task canceled");
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception + task.Exception.Message);
                throw new Exception("task faulted");
            }

            // Firebase user has been created.
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            // Save extra details about the user in the database
            /*
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
            }
            */
        });
    }

    public async Task LoginAsync(string email, string password)
    {
        Debug.Log("Trying to login with email and password.");
        var auth = FirebaseAuth.DefaultInstance;
        await auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.Log("SignInWithEmailAndPasswordAsync was canceled.");
                throw new Exception("task canceled");
            }
            if (task.IsFaulted)
            {
                Debug.Log("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                throw new Exception("task faulted");
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            // get extra information about the user from the db and return it
            /*
            if (result.User != null)
            {
                var allUsers = await m_FirebaseClient.Child("users").OnceAsync<User>();

                return new LoginResult()
                {
                    IsLoggedIn = true,
                    LoggedInUser = allUsers.First(user => user.Object.email == email).Object
                };
            }
            */
        });
    }

    public async Task ResetPasswordAsync(string email)
    {
        Debug.Log("Trying to send Password Reset email");
        var auth = FirebaseAuth.DefaultInstance;
        await auth.SendPasswordResetEmailAsync(email).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SendPasswordResetEmailAsync was canceled.");
                throw new Exception("task canceled");
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
                throw new Exception("task faulted");
            }

            Debug.Log("Password reset email sent successfully.");
        });
    }

    public async Task AnonymousLoginAsync()
    {
        Debug.Log("Trying to login anonymously.");
        var auth = FirebaseAuth.DefaultInstance;
        await auth.SignInAnonymouslyAsync().ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                throw new Exception("task canceled");
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                throw new Exception("task faulted");
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    public async Task LogoutAsync()
    {
        throw new System.NotImplementedException();
    }
}