using UnityEngine;
using UnityEngine.UI;

public class RegisterScreenScript : MonoBehaviour
{
    private InputField EmailUIElement;
    private InputField PasswordUIElement;
    private InputField IDUIElement;
    private InputField NameUIElement;
    private Dropdown TypeUIElement;
   
    void Start ()
    {
        EmailUIElement = GameObject.Find("EmailInput").GetComponent<InputField>();
        PasswordUIElement = GameObject.Find("PasswordInput").GetComponent<InputField>();
        IDUIElement = GameObject.Find("IDInput").GetComponent<InputField>();
        NameUIElement = GameObject.Find("NameInput").GetComponent<InputField>();
        TypeUIElement = GameObject.Find("TypeDropdown").GetComponent<Dropdown>();
    }

    public void RegisterButton_Click()
    {
        //TODO: validate input parameters
        ServicesManager.GetAuthManager().Register(
            EmailUIElement.text,
            NameUIElement.text, 
            PasswordUIElement.text,
            IDUIElement.text,
            TypeUIElement.options[TypeUIElement.value].text);
    }
}
