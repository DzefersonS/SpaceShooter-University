using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private float m_FireCooldown;

        [SerializeField] protected GameObject shot;
        [SerializeField] protected Transform shotSpawn;

        protected float m_TimeRemaining = 0.0f;
        protected AudioSource m_AudioSource = default;

        protected void Awake()
        {
            m_TimeRemaining = m_FireCooldown;
            m_AudioSource = GetComponent<AudioSource>();
        }

        protected void Update()
        {
            m_TimeRemaining -= Time.deltaTime;
            if (m_TimeRemaining <= 0.0f)
            {
                Fire();
                m_TimeRemaining += m_FireCooldown;
            }
        }

        protected abstract void Fire();
    }
}