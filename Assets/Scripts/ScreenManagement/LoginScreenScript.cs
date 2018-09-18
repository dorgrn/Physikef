using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

public class LoginScreenScript : MonoBehaviour
{
    [Inject] private ApplicationManager m_ApplicationManager;

    [SerializeField] private InputField m_EmailUiElement;
    [SerializeField] private InputField m_PasswordUiElement;
    [SerializeField] private Text m_ErrorLabel;


    void Start()
    {
        m_ErrorLabel.text = string.Empty;
    }

    public void CreateNewAccount_Click()
    {
        SceneManager.LoadScene("RegisterScreen");
    }

    public async void LoginButton_Click()
    {
        m_ErrorLabel.text = string.Empty;
        string inputEmail = m_EmailUiElement.text;
        string inputPassword = m_PasswordUiElement.text;

        try
        {
            validateInputs(inputEmail, inputPassword);

            LoginResult loginResult = await ServicesManager.GetAuthManager()
                .LoginAsync(inputEmail, inputPassword);


            if (!loginResult.IsLoggedIn)
            {
                logError($"User {inputEmail} isn't registered. Try again.");
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
            Debug.LogError(e.ToString());
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

    private void logError(string message)
    {
        m_ErrorLabel.text = message;
        throw new Exception(message);
    }


    private void validateInputs(string inputEmail, string inputPassword)
    {
        if (!InputValidator.isValidEmail(inputEmail))
        {
            logError($"Email {inputEmail} isn't valid.");
        }

        if (!InputValidator.isValidPassword(inputPassword))
        {
            logError($"Password {inputPassword} isn't valid");
        }
    }
}