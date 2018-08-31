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
        ServicesManager.GetAuthManager().Login(EmailUIElement.text, PasswordUIElement.text);
    }
}
