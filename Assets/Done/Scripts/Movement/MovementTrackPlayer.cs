using UnityEngine;
using System.Collections;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementTrackPlayer : MonoBehaviour
    {
        public Done_Boundary boundary;
        public float tilt;
        public float smoothing;
        public float trackingSpeed; // New variable for how fast it tracks the player

        private Rigidbody m_RigidBody;
        private float m_CurrentSpeed;
        private Transform m_PlayerTransform;

        private void Awake()
        {
            m_PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Start()
        {
            m_RigidBody = GetComponent<Rigidbody>();
            m_CurrentSpeed = m_RigidBody.velocity.z;
        }

        private void FixedUpdate()
        {
            // Track the player horizontally
            float targetX = Mathf.Clamp(m_PlayerTransform.position.x, boundary.xMin, boundary.xMax);
            float newManeuver = Mathf.MoveTowards(m_RigidBody.velocity.x, targetX, trackingSpeed * Time.deltaTime);

            m_RigidBody.velocity = new Vector3(newManeuver, 0.0f, m_CurrentSpeed);
            m_RigidBody.position = new Vector3
            (
                Mathf.Clamp(m_RigidBody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(m_RigidBody.position.z, boundary.zMin, boundary.zMax)
            );

            m_RigidBody.rotation = Quaternion.Euler(0, 0, m_RigidBody.velocity.x * -tilt);
        }
    } // class MovementTrackPlayer
} // namespace SpaceShooter
