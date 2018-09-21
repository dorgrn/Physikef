using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPasswordScreenScript : MonoBehaviour
{
    private InputField EmailUIElement;
    private Text m_ErrorText;

    void Start()
    {
        EmailUIElement = GameObject.Find("EmailInput").GetComponent<InputField>();
        m_ErrorText = GameObject.FindGameObjectWithTag("ErrorText").GetComponent<Text>();
        m_ErrorText.text = String.Empty;
    }

    public async void SendResetPasswordEmail_Click()
    {
        string email = EmailUIElement.text;
        if (!InputValidator.isValidEmail(email))
        {
            m_ErrorText.text = $"email {email} isn't valid";
            throw new ArgumentException(m_ErrorText.text);
        }

        await ServicesManager.GetAuthManager().ResetPasswordAsync(email);
    }
}