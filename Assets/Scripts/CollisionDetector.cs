using UnityEngine;

public class CollisionDetector : MonoBehaviour {
    private bool isContact = false;
    ParticleSystem.MainModule main;
    [SerializeField] float colorChangeDelay = 2f;

    void OnParticleCollision(GameObject other)
    {
        if (!isContact && other && other.tag.Equals("Target"))
        {
            isContact = true;
            main.startColor = new ParticleSystem.MinMaxGradient(Color.black);
        }
    }

    // Use this for initialization
    void Start () {
        main = GetComponent<ParticleSystem>().main;
    }
	
	// Update is called once per frame
	void Update () {
        checkContact();
	}

    private void checkContact()
    {
        
        if (isContact)
        {

            colorChangeDelay -= Time.deltaTime;
            if (colorChangeDelay < 0)
            {
                main.startColor = new ParticleSystem.MinMaxGradient(Color.blue);
            }
        }
    }
}
