using Attributes;
using UnityEditor;

public class ApplicationManager
{
    private readonly AttributContainer attributeContainer;
    private bool m_hardCodedAnswers = true;

    public bool isHardCodedAnswers
    {
        get { return m_hardCodedAnswers; }
    }

    protected ApplicationManager()
    {
        attributeContainer = new AttributContainer();
    }


    public static void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
		#endif
    }

    public AttributContainer GetAttributeContainer()
    {
        return attributeContainer;
    }
}