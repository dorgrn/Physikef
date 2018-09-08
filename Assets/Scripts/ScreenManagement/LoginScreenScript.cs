using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

public class LoginScreenScript : MonoBehaviour
{
    [Inject] private ApplicationManager m_ApplicationManager;
    [SerializeField] private InputField EmailUIElement;
    [SerializeField] private InputField PasswordUIElement;


    void Start()
    {
    }

    public void CreateNewAccount_Click()
    {
        SceneManager.LoadScene("RegisterScreen");
    }

    public async void LoginButton_Click()
    {
        //TODO: add input validation checks
        try
        {
            LoginResult loginResult = await ServicesManager.GetAuthManager()
                .LoginAsync(EmailUIElement.text, PasswordUIElement.text);

            if (!loginResult.IsLoggedIn)
            {
                return;
            }

            m_ApplicationManager.CurrentUser = loginResult.LoggedInUser;
            if (loginResult.LoggedInUser.usertype == "Teacher")
            {
                Debug.Log("Teacher options");
                SceneManager.LoadScene("TeacherOptionsScreen");
            }
            else
            {
                Debug.Log("Student options");
                SceneManager.LoadScene("StudentOptionsScreen");
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }
    }

    public async void SkipButton_Click()
    {
        try
        {
            await ServicesManager.GetAuthManager().AnonymousLoginAsync();
            SceneManager.LoadScene("AnonymousOptionsScreen");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void ForgotPasswordButton_Click()
    {
        SceneManager.LoadScene("ForgotPasswordScreen");
    }
}