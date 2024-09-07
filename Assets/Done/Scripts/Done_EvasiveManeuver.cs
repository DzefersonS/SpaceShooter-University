using UnityEngine;
using System.Collections;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class Done_EvasiveManeuver : MonoBehaviour
    {
        public Done_Boundary boundary;
        public float tilt;
        public float dodge;
        public float smoothing;
        public Vector2 startWait;
        public Vector2 maneuverTime;
        public Vector2 maneuverWait;

        private Rigidbody m_RigidBody = default;
        private float m_CurrentSpeed = default;
        private float m_TargetManeuver = default;

        private void Start()
        {
            m_RigidBody = GetComponent<Rigidbody>();
            m_CurrentSpeed = m_RigidBody.velocity.z;
            StartCoroutine(Evade());
        }

        private IEnumerator Evade()
        {
            yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
            while (true)
            {
                m_TargetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
                yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
                m_TargetManeuver = 0;
                yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
            }
        }

        private void FixedUpdate()
        {
            float newManeuver = Mathf.MoveTowards(m_RigidBody.velocity.x, m_TargetManeuver, smoothing * Time.deltaTime);
            m_RigidBody.velocity = new Vector3(newManeuver, 0.0f, m_CurrentSpeed);
            m_RigidBody.position = new Vector3
            (
                Mathf.Clamp(m_RigidBody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(m_RigidBody.position.z, boundary.zMin, boundary.zMax)
            );

            m_RigidBody.rotation = Quaternion.Euler(0, 0, m_RigidBody.velocity.x * -tilt);
        }
    } //class Done_EvasiveManeuver
} //namespace SpaceShooter