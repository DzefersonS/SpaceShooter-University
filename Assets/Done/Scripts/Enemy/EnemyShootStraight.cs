using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyShootStraight : Enemy
    {
        protected override void Fire()
        {
            Vector3 rotation = shotSpawn.rotation.eulerAngles;
            rotation.z = 0;
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotation));
            m_AudioSource.Play();
        }
    }
}