using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    [SerializeField] private GameObject Cannon;
    [SerializeField] private GameObject CannonBallPrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(CannonBallPrefab, Cannon.transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(Cannon.transform.eulerAngles.normalized * 10000);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.position.Set(this.transform.position.x + 10, this.transform.position.y, this.transform.position.z);
            //Cannon.transform.position.Set(Cannon.transform.position.x + 10, Cannon.transform.position.y, Cannon.transform.position.z);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
        // multiplying it by 'speed' - our public player speed that appears in the inspector
        this.GetComponent<Rigidbody>().AddForce(movement * 10);



    }
}
