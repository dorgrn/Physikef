using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] TextMesh forcesText;
    private int nextUpdate = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            forcesText.text = string.Format("Height: {0}m\nRotation: ({1},{2},{3})", target.position.y + 1, Mathf.FloatToHalf(target.eulerAngles.x), Mathf.FloatToHalf(target.eulerAngles.y), Mathf.FloatToHalf(target.eulerAngles.z));
        }

    }
}
