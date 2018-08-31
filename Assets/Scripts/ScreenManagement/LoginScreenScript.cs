using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class LoginScreenScript : MonoBehaviour
{
    private InputField EmailUIElement;
    private InputField PasswordUIElement;

    void Start()
    {
        EmailUIElement = GameObject.Find("EmailInput").GetComponent<InputField>();
        PasswordUIElement = GameObject.Find("PasswordInput").GetComponent<InputField>();
    }

    public void CreateNewAccount_Click()
    {
        //SceneManager.LoadScene("RegisterScreen");
        var auth = FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(EmailUIElement.text, PasswordUIElement.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception + task.Exception.Message);
                return;
            }

            // Firebase user has been created.
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }



    public void LoginButton_Click()
    {
        Debug.Log("Trying to login.");
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync(EmailUIElement.text, PasswordUIElement.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.Log("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
}
