using System;
using System.IO;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

public class AuthenticationManager : IAuthenticationManager
{
    private FirebaseAuth m_Auth;
    private FirebaseUser m_User;

    public AuthenticationManager()
    {
        m_Auth = FirebaseAuth.DefaultInstance;
        m_Auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }


    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (m_Auth.CurrentUser != m_User)
        {
            bool signedIn = m_User != m_Auth.CurrentUser && m_Auth.CurrentUser != null;
            if (!signedIn && m_User != null)
            {
                Debug.Log("Signed out " + m_User.UserId);
            }

            m_User = m_Auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + m_User.UserId);
            }
        }
    }

    void OnDestroy()
    {
        m_Auth.StateChanged -= AuthStateChanged;
        m_Auth = null;
    }

    public async Task RegisterAsync(string email, string userDisplayName, string password, string userID,
        string userType)
    {
        await m_Auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(async task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                throw new Exception("task canceled");
            }

            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception +
                               task.Exception.Message);
                throw new Exception("task faulted");
            }

            // Firebase user has been created.
            FirebaseUser newUser = task.Result;

            if (newUser != null)
            {
                var registeredUser = new User()
                {
                    displayname = userDisplayName,
                    email = email,
                    userid = userID,
                    usertype = userType
                };

                await ServicesManager.GetDataAccessLayer().AddUserAsync(registeredUser);
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
            }
        });
    }

    public async Task<LoginResult> LoginAsync(string email, string password)
    {
        Debug.Log("Trying to login with email and password.");

        Task<LoginResult> resultTask = await m_Auth.SignInWithEmailAndPasswordAsync(email, password)
            .ContinueWith(async task =>
            {
                if (task.IsCanceled)
                {
                    Debug.Log("SignInWithEmailAndPasswordAsync was canceled.");
                    throw new Exception($"Task canceled: {task.Result}");
                }

                if (task.IsFaulted)
                {
                    Debug.Log("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    throw new Exception($"Task faulted: {task.Result}");
                }

                FirebaseUser newUser = task.Result;

                // get extra info about user
                if (newUser != null)
                {
                    var loggedInUser = await ServicesManager.GetDataAccessLayer().GetUserByEmailAsync(email);
                    Debug.LogFormat("User signed in successfully: {0} ({1})",
                        newUser.DisplayName, newUser.UserId);

                    return new LoginResult()
                    {
                        IsLoggedIn = true,
                        LoggedInUser = loggedInUser,
                    };
                }

                return new LoginResult()
                {
                    IsLoggedIn = false,
                };
            });
        return await resultTask;
    }

    public async Task ResetPasswordAsync(string email)
    {
        Debug.Log("Trying to send Password Reset email");

        await m_Auth.SendPasswordResetEmailAsync(email).ContinueWith(task =>
        {
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

    public string GetCurrentUserEmail()
    {
        return m_User?.Email ?? string.Empty;
    }

    public async Task AnonymousLoginAsync()
    {
        Debug.Log("Trying to login anonymously.");

        await m_Auth.SignInAnonymouslyAsync().ContinueWith(task =>
        {
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
}