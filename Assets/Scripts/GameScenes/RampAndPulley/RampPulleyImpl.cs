using UnityEngine;

public class RampPulleyImpl : PulleyImpl
{
    private const float RAMP_INCLINE = 30f;
    private const float RAMP_RIGHT_EDGE = 2f;


    private float getDeltaForce()
    {
        // based on actual formula
        float forceBoxAir = rbObjectRight.mass;
        float forceBoxRamp = rbObjectLeft.mass * Mathf.Sin(RAMP_INCLINE);
        return Mathf.Abs(forceBoxAir - forceBoxRamp);
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (m_ObjectLeft.transform.position.x < RAMP_RIGHT_EDGE)
        {
            rbObjectLeft.MovePosition(rbObjectLeft.transform.position +
                                      rbObjectLeft.transform.forward * Time.deltaTime);
            rbObjectRight.MovePosition(rbObjectRight.transform.position + -rbObjectLeft.transform.up * Time.deltaTime);
        }
    }
}