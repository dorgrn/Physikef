using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Physikef.ScreenManagement
{
    public class RegisterScreenScript : MonoBehaviour
    {
        private const string LOGIN_SCREEN_NAME = "LoginScreen";
        private InputField EmailUIElement;
        private InputField PasswordUIElement;
        private InputField IDUIElement;
        private InputField NameUIElement;
        private Dropdown TypeUIElement;
        [SerializeField] private Text m_ErrorText;

        void Start()
        {
            m_ErrorText.text = string.Empty;
            EmailUIElement = GameObject.Find("EmailInput").GetComponent<InputField>();
            PasswordUIElement = GameObject.Find("PasswordInput").GetComponent<InputField>();
            IDUIElement = GameObject.Find("IDInput").GetComponent<InputField>();
            NameUIElement = GameObject.Find("NameInput").GetComponent<InputField>();
            TypeUIElement = GameObject.Find("TypeDropdown").GetComponent<Dropdown>();
        }

        public async void RegisterButton_Click()
        {
            m_ErrorText.text = string.Empty;

            var email = EmailUIElement.text;
            var userDisplayName = NameUIElement.text;
            var password = PasswordUIElement.text;
            var id = IDUIElement.text;

            try
            {
                validateInput(email, userDisplayName, password, id);


                await ServicesManager.GetAuthManager().RegisterAsync(
                    email,
                    userDisplayName,
                    password,
                    id,
                    TypeUIElement.options[TypeUIElement.value].text);


                SceneManager.LoadScene(LOGIN_SCREEN_NAME);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        private void validateInput(string email, string userDisplayName, string password, string id)
        {
            if (!InputValidator.isValidEmail(email))
            {
                logError($"email {email} isn't a valid email");
            }

            if (string.IsNullOrEmpty(userDisplayName))
            {
                logError("user name can't be empty");
            }

            if (!InputValidator.isValidPassword(password))
            {
                logError("password isn't valid");
            }

            if (!InputValidator.isIdValid(id))
            {
                logError("Id isn't valid");
            }
        }

        public void BackButton_OnClick()
        {
            SceneManager.LoadScene(LOGIN_SCREEN_NAME);
        }

        private void logError(string message)
        {
            m_ErrorText.text = message;
            throw new Exception(message);
        }
    }
}