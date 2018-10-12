using UnityEngine;

public class PulleyImpl : MonoBehaviour
{
    [SerializeField] protected GameObject m_ObjectLeft;
    [SerializeField] protected GameObject m_ObjectRight;
    [SerializeField] protected GameObject m_Pulley;
    [SerializeField] LineRenderer lineObjectLeft;
    [SerializeField] LineRenderer lineObjectLeftRight;

    protected float m_Delta;
    protected Rigidbody rbObjectLeft;
    protected Rigidbody rbObjectRight;


    private void Start()
    {
        rbObjectLeft = m_ObjectLeft.GetComponent<Rigidbody>();
        rbObjectRight = m_ObjectRight.GetComponent<Rigidbody>();
    }

    private void setLinePositionWithPulley(LineRenderer line, GameObject go)
    {
        var downPrecision = Vector3.down * 1.2f;
        line.SetPosition(0, m_Pulley.transform.position + downPrecision);
        line.SetPosition(1, go.transform.position);
    }

    protected void FixedUpdate()
    {
        setLinePositionWithPulley(lineObjectLeftRight, m_ObjectRight);
        setLinePositionWithPulley(lineObjectLeft, m_ObjectLeft);
    }
}