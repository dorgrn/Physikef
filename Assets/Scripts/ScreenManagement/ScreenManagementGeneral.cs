using UnityEngine;
using UnityEngine.UI;

public class ScreenManagementGeneral : MonoBehaviour
{
    [SerializeField] private AudioClip m_ButtonClickSound;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = gameObject.AddComponent<AudioSource>();
        m_AudioSource.clip = m_ButtonClickSound;
        setButtonsClip();
    }

    private void setButtonsClip()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(delegate { m_AudioSource.Play(); });
        }
    }


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