using UnityEngine;

namespace Physikef.ScreenManagement
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        private AudioSource m_AudioSource;

        private void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(transform.gameObject);
            m_AudioSource.Play();
        }

        public void PlayMusic()
        {
            if (m_AudioSource.isPlaying)
                return;
            m_AudioSource.Play();
        }

        public void StopMusic()
        {
            m_AudioSource.Stop();
        }
    }
}