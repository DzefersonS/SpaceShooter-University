using System.Collections;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyBoss : Enemy
    {
        public Done_Boundary boundary;
        public float dodge;
        public float smoothing;
        public Vector2 startWait;
        public Vector2 maneuverTime;
        public Vector2 maneuverWait;
        public float targetZPosition = 14.0f;
        public float zMoveSpeed = 5.0f;

        private Rigidbody m_RigidBody;
        private float m_TargetManeuver;

        protected void Start()
        {
            m_RigidBody = GetComponent<Rigidbody>();
            StartCoroutine(Evade());
        }

        private IEnumerator Evade()
        {
            yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
            while (true)
            {
                m_TargetManeuver = Random.Range(-dodge, dodge);
                yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
                m_TargetManeuver = 0;
                yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
            }
        }

        protected override void Fire()
        {
            Vector3 rotation = shotSpawn.rotation.eulerAngles;
            rotation.z = 0;
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotation));
            m_AudioSource.Play();
        }

        private void FixedUpdate()
        {
            float newManeuver = Mathf.MoveTowards(m_RigidBody.velocity.x, m_TargetManeuver, smoothing * Time.deltaTime);
            m_RigidBody.velocity = new Vector3(newManeuver, 0.0f, m_RigidBody.velocity.z);

            float newZPosition = Mathf.MoveTowards(m_RigidBody.position.z, targetZPosition, zMoveSpeed * Time.deltaTime);

            m_RigidBody.position = new Vector3
            (
                Mathf.Clamp(m_RigidBody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                newZPosition
            );
        }
    }
}
