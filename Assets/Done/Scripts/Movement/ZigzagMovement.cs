using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class ZigzagMovement : MonoBehaviour
    {
        public Done_Boundary boundary;
        public float tilt;
        public float zigzagWidth; // Width of the zigzag pattern
        public float zigzagSpeed; // Speed of the zigzag movement
        public float moveSpeed; // Forward movement speed

        private Rigidbody m_RigidBody;
        private float m_StartTime;

        private void Start()
        {
            m_RigidBody = GetComponent<Rigidbody>();
            m_StartTime = Time.time; // Record the start time for zigzag calculation
        }

        private void FixedUpdate()
        {
            // Calculate the horizontal zigzag offset
            float elapsed = Time.time - m_StartTime;
            float zigzagOffset = Mathf.Sin(elapsed * zigzagSpeed) * zigzagWidth;

            // Calculate the new position based on zigzag and move speed
            Vector3 newPosition = new Vector3
            (
                Mathf.Clamp(transform.position.x + zigzagOffset, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(transform.position.z - moveSpeed * Time.deltaTime, boundary.zMin, boundary.zMax)
            );

            // Apply the new position
            m_RigidBody.position = newPosition;

            // Set velocity to move in the z direction
            m_RigidBody.velocity = new Vector3(0.0f, 0.0f, -moveSpeed);

            // Apply tilt based on horizontal movement
            m_RigidBody.rotation = Quaternion.Euler(0, 0, m_RigidBody.velocity.z * -tilt);
        }
    } // class ZigzagMovement
} // namespace SpaceShooter
