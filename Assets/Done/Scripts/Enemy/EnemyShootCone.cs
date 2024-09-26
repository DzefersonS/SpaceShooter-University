using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyShootCone : Enemy
    {
        protected override void Fire()
        {
            Vector3 rotation = shotSpawn.rotation.eulerAngles;
            rotation.z = 0;
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotation));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotation) * Quaternion.Euler(new Vector3(0.0f, 30.0f, 0.0f)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotation) * Quaternion.Euler(new Vector3(0.0f, -30.0f, 0.0f)));
            m_AudioSource.Play();
        }
    }
}