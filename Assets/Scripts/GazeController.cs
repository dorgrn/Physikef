using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void MoveBox()
    {
        Debug.Log("in gaze!!!!");
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 10), step);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MoveBox();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
