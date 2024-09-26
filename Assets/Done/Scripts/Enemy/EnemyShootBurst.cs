using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyShootBurst : Enemy
    {
        [SerializeField] private float m_DelayBetweenShots;
        [SerializeField] private int m_BurstCount;

        protected override void Fire()
        {
            StartCoroutine(FireBurst());
        }

        private IEnumerator FireBurst()
        {
            for (int i = 0; i < m_BurstCount; i++)
            {
                Vector3 rotation = shotSpawn.rotation.eulerAngles;
                rotation.z = 0;
                Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotation));
                m_AudioSource.Play();
                yield return new WaitForSeconds(m_DelayBetweenShots);
            }
        }
    }
}