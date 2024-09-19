using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class Done_DestroyByContact : MonoBehaviour
    {
        [SerializeField] private IntEvent m_PlayerHealthChangeEvent;
        [SerializeField] private IntEvent m_AddScoreEvent;

        public GameObject explosion;
        public GameObject playerExplosion;
        public int scoreValue;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Boundary" || other.tag == "Enemy")
            {
                return;
            }

            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (other.CompareTag("Player"))
            {
                m_PlayerHealthChangeEvent.value = -1;
            }

            m_AddScoreEvent.value = scoreValue;
            Destroy(gameObject);
        }
    } //class Done_DestroyByContact
} //namespace SpaceShooter