using UnityEngine;
using Utils;

namespace SpaceShooter
{
    [System.Serializable]
    public class Done_Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    [RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private int m_MaxHealth;
        [SerializeField] private SOEvent m_PlayerDeathEvent;

        public float speed;
        public float tilt;
        public Done_Boundary boundary;

        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;

        private Done_GameController m_GameController;
        private Rigidbody m_RigidBody = default;
        private AudioSource m_AudioSource = default;
        private float m_NextFire = default;
        private int m_Health = 0;

        private void Awake()
        {
            m_RigidBody = GetComponent<Rigidbody>();
            m_AudioSource = GetComponent<AudioSource>();
            m_Health = m_MaxHealth;

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

        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > m_NextFire)
            {
                m_NextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                m_AudioSource.Play();
            }
        }

        private void FixedUpdate()
        {
            Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed;
            m_RigidBody.velocity = velocity;

            m_RigidBody.position = new Vector3
            (
                Mathf.Clamp(m_RigidBody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(m_RigidBody.position.z, boundary.zMin, boundary.zMax)
            );

            m_RigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, velocity.x * -tilt);
        }
    } //class Player
} //namespace SpaceShooter