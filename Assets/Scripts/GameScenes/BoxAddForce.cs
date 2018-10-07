using UnityEngine;

public class BoxAddForce : MonoBehaviour
{
    public float m_Mass;
    public float m_MassOfOther;
    private float m_Accelration;

    // trying to reanct https://stackoverflow.com/questions/36702654/how-to-approach-weighing-scales-in-unity-2d
    void Start()
    {
        m_Accelration = ((9.81f * (m_Mass - m_MassOfOther))) / (m_Mass + m_MassOfOther);
        GetComponent<Rigidbody>().AddForce(Vector3.down * m_Mass);
    }

    void Update()
    {
//        GetComponent<Rigidbody>().AddForce(Vector3.down * m_Mass * m_Accelration);
    }
}