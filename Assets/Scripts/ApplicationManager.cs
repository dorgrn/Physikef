using Attributes;
using UnityEditor;

public class ApplicationManager
{
    private readonly AttributContainer attributeContainer;

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