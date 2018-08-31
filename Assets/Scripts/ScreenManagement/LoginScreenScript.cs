using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
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

    public void LoginButton_Click()
    {
        //TODO: add input validation checks
        try
        {
            ServicesManager.GetAuthManager().Login(EmailUIElement.text, PasswordUIElement.text);
            //TODO: move to next scene according to user type
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void SkipButton_Click()
    {
        try
        {
            ServicesManager.GetAuthManager().AnonymousLogin();
            SceneManager.LoadScene("AnonymousOptionsScreen");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
