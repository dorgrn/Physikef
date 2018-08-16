using UnityEngine;

namespace Physikef
{
    public class CollisionDetector : MonoBehaviour
    {
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

        void Start()
        {
            main = GetComponent<ParticleSystem>().main;
        }

        void Update()
        {
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
}