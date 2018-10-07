using UnityEngine;
using UnityEngine.UI;

public class ScreenManagementGeneral : MonoBehaviour
{
    public static void LogError(string errorMessage)
    {
        Text errorText = GameObject.FindGameObjectWithTag("ErrorText").GetComponent<Text>();
        errorText.color = Color.red;
        errorText.text = errorMessage;
    }

    public static void LogSuccess(string message)
    {
        Text text = GameObject.FindGameObjectWithTag("ErrorText").GetComponent<Text>();
        text.color = Color.green;
        text.text = message;
    }
}