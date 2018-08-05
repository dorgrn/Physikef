using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PropertyController;

public class FrictionProperty : PropertyController.PropertyController
{ 
    public override void UpdateProperty()
    {
        Collider coll;

        coll = m_ObjectToUpdate.GetComponent<Collider>();
        coll.material.staticFriction = Value;
    }
}
