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
        [SerializeField] private PlayerInputsSO playerControls; // Reference to the ScriptableObject

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

        // Smoothing parameters
        public float smoothTime = 0.1f; // Time to smooth out the input
        private Vector3 currentVelocity = Vector3.zero;

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
            if (Input.GetKey(playerControls.shoot) && Time.time > m_NextFire)
            {
                m_NextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                m_AudioSource.Play();
            }
        }

        private void FixedUpdate()
        {
            float moveHorizontal = 0.0f;
            float moveVertical = 0.0f;

            // Input handling based on ScriptableObject
            if (Input.GetKey(playerControls.moveForward)) moveVertical += 1;
            if (Input.GetKey(playerControls.moveBackward)) moveVertical -= 1;
            if (Input.GetKey(playerControls.moveLeft)) moveHorizontal -= 1;
            if (Input.GetKey(playerControls.moveRight)) moveHorizontal += 1;

            // Smooth the input values
            Vector3 targetVelocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
            m_RigidBody.velocity = Vector3.SmoothDamp(m_RigidBody.velocity, targetVelocity, ref currentVelocity, smoothTime);

            // Clamp the position within boundaries
            m_RigidBody.position = new Vector3
            (
                Mathf.Clamp(m_RigidBody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(m_RigidBody.position.z, boundary.zMin, boundary.zMax)
            );

            // Rotate the player
            m_RigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, m_RigidBody.velocity.x * -tilt);
        }
    } //class Player
} //namespace SpaceShooter