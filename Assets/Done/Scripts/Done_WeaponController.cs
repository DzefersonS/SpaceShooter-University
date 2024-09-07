using UnityEngine;

namespace SpaceShooter
{
    public class Done_WeaponController : MonoBehaviour
    {
        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;
        public float delay;

        private float m_TimeRemaining = 0.0f;

        private void Start()
        {
            m_TimeRemaining = fireRate + delay;
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
            GetComponent<AudioSource>().Play();
        }
    } //class Done_WeaponController
} //namespace SpaceShooter