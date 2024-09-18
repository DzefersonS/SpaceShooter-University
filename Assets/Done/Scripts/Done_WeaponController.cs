using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class Done_WeaponController : MonoBehaviour
    {
        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;
        public float delay;

        private AudioSource m_AudioSource = default;
        private float m_TimeRemaining = 0.0f;

        private void Start()
        {
            m_TimeRemaining = fireRate + delay;
            m_AudioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            m_TimeRemaining -= Time.deltaTime;
            if (m_TimeRemaining < 0.0f)
            {
                m_TimeRemaining += fireRate;
                Fire();
            }
        }

        private void Fire()
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            m_AudioSource.Play();
        }
    } //class Done_WeaponController
} //namespace SpaceShooter