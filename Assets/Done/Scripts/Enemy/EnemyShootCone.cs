using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyShootCone : Enemy
    {
        protected override void Fire()
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation * Quaternion.Euler(new Vector3(0.0f, 30.0f, 0.0f)));
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation * Quaternion.Euler(new Vector3(0.0f, -30.0f, 0.0f)));
            m_AudioSource.Play();
        }
    }
}