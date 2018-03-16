using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    [SerializeField] float gravity = 1f;
    [SerializeField] float massMult = 1f;
    [SerializeField] float dragMult;
    [SerializeField] float angularDragMult;
    
	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, gravity, 0);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
