using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class Done_DestroyByContact : MonoBehaviour
    {
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
                other.GetComponent<Player>().ModifyHealth(-1);
            }

            m_AddScoreEvent.value = scoreValue;
            Destroy(gameObject);
        }
    }
}