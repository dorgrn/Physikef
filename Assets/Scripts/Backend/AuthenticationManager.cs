using System;
using Firebase.Auth;
using UnityEngine;

public class AuthenticationManager : IAuthenticationManager
{
    public void Register(string email, string userDisplayName, string password,string userID, string userType)
    {
        var auth = FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
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
        }).Wait();
    }

    public void Login(string email, string password)
    {
        Debug.Log("Trying to login with email and password.");
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
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
        }).Wait();
    }

    public void ResetPassword(string email)
    {
        throw new System.NotImplementedException();

    }

    public void AnonymousLogin()
    {
        Debug.Log("Trying to login anonymously.");
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignInAnonymouslyAsync().ContinueWith(task => {
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
        }).Wait();
    }

    public void Logout()
    {
        throw new System.NotImplementedException();
    }
}