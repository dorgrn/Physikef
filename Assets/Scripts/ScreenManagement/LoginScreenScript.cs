using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("RegisterScreen");
    }

    public async void LoginButton_Click()
    {
        //TODO: add input validation checks
        try
        {
            var loginResult = await ServicesManager.GetAuthManager().LoginAsync(EmailUIElement.text, PasswordUIElement.text);

            if (loginResult.IsLoggedIn)
            {
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

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
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
