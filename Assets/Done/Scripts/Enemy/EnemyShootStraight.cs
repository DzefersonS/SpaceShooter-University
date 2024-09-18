using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyShootStraight : Enemy
    {
        protected override void Fire()
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            m_AudioSource.Play();
        }
    }
}