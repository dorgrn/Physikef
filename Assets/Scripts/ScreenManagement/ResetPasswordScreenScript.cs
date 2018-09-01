using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPasswordScreenScript : MonoBehaviour
{
    private InputField EmailUIElement;
   
    void Start()
    {
        EmailUIElement = GameObject.Find("EmailInput").GetComponent<InputField>();
    }

    public async void SendResetPasswordEmail_Click()
    {
        // TODO: validate input
         await ServicesManager.GetAuthManager().ResetPasswordAsync(EmailUIElement.text);
    }
}
