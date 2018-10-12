using UnityEngine;

public class FixedPulleyImpl : PulleyImpl
{
    private const float MAX_HEIGHT = 5.5f;

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (m_ObjectRight.transform.position.y < MAX_HEIGHT)
        {
            rbObjectLeft.MovePosition(rbObjectLeft.transform.position +
                                      -rbObjectLeft.transform.up * Time.deltaTime);
            rbObjectRight.MovePosition(rbObjectRight.transform.position +
                                       rbObjectRight.transform.up * Time.deltaTime);
        }
    }
}