using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PropertyController;

public class HeightProperty : PropertyController.PropertyController
{ 
    public override void UpdateProperty()
    {
        DontDestroyOnLoad(m_ObjectToUpdate.gameObject);
        Collider ball = m_ObjectToUpdate.GetComponent<Collider>();
        Vector3 oldVecValues = ball.transform.position;
        m_ObjectToUpdate.GetComponent<Collider>().transform.position = new Vector3(oldVecValues.x, Value, oldVecValues.z);
    }
}
