using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class Done_DestroyByContact : MonoBehaviour
    {
        [SerializeField] private SOEvent m_PlayerDamageEvent;

        public GameObject explosion;
        public GameObject playerExplosion;
        public int scoreValue;

        private Done_GameController m_GameController;

        void Start()
        {
            GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (gameControllerObject != null)
            {
                m_GameController = gameControllerObject.GetComponent<Done_GameController>();
            }
            if (m_GameController == null)
            {
                Debug.Log("Cannot find 'GameController' script");
            }
        }

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
                m_PlayerDamageEvent.Raise();
            }

            m_GameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    } //class Done_DestroyByContact
} //namespace SpaceShooter