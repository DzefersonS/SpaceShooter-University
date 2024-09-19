using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class ZigzagMovement : MonoBehaviour
    {
        public Done_Boundary boundary;
        public float tilt;
        public float zigzagWidth;
        public float zigzagSpeed;
        public float moveSpeed;

        private Rigidbody m_RigidBody;
        private float m_StartTime;

        private void Start()
        {
            m_RigidBody = GetComponent<Rigidbody>();
            m_StartTime = Time.time;
        }

        private void FixedUpdate()
        {
            float elapsed = Time.time - m_StartTime;
            float zigzagOffset = Mathf.Sin(elapsed * zigzagSpeed) * zigzagWidth;

            Vector3 newPosition = new Vector3
            (
                Mathf.Clamp(transform.position.x + zigzagOffset, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(transform.position.z - moveSpeed * Time.deltaTime, boundary.zMin, boundary.zMax)
            );

            m_RigidBody.position = newPosition;

            m_RigidBody.velocity = new Vector3(0.0f, 0.0f, -moveSpeed);

            m_RigidBody.rotation = Quaternion.Euler(0, 0, m_RigidBody.velocity.z * -tilt);
        }
    }
}