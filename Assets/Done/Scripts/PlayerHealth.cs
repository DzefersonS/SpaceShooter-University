using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace SpaceShooter
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private GameObject m_PlayerExplosion;
        [SerializeField] private Slider m_HealthSlider;
        [SerializeField] private SOEvent m_PlayerDamageEvent;
        [SerializeField] private SOEvent m_PlayerDeathEvent;
        [SerializeField] private int m_MaxHealth;

        private int m_Health = default;

        private void Awake()
        {
            m_HealthSlider.maxValue = m_MaxHealth;
            m_HealthSlider.value = m_MaxHealth;
            m_Health = m_MaxHealth;
            m_PlayerDamageEvent.Register(TakeDamage);
        }

        private void OnDestroy()
        {
            m_PlayerDamageEvent.Unregister(TakeDamage);
        }

        private void TakeDamage()
        {
            m_HealthSlider.value = --m_Health;
            Instantiate(m_PlayerExplosion, transform.position, transform.rotation);
            if (m_Health <= 0)
            {
                m_PlayerDeathEvent.Raise();
            }
        }
    }
}