using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PropertyController;

public class GravityProperty : PropertyController.PropertyController
{ 
    public override void UpdateProperty()
    {
       Physics.gravity = new Vector3(0, -1*Value, 0);
    }
}
