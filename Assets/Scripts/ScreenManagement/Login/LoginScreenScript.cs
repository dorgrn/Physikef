using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScreenScript : MonoBehaviour
{
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

        validateInputs(inputEmail, inputPassword);

        try
        {
            LoginResult loginResult = await ServicesManager.GetAuthManager()
                .LoginAsync(inputEmail, inputPassword);
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
            logError($"User {inputEmail} isn't registered. Try again.");
        }

    }


    public async void SkipButton_Click()
    {
        try
        {
            await ServicesManager.GetAuthManager().AnonymousLoginAsync();
            SceneManager.LoadScene("StudentOptionsScreen");
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