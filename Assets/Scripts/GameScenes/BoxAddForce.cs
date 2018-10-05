using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAddForce : MonoBehaviour
{

    public float thrust;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down * thrust);
    }

    void Update()
    {

    }
}
