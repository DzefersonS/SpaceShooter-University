using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace SpaceShooter
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private GameObject m_Player;
        [SerializeField] private GameObject m_PlayerExplosion;
        [SerializeField] private Slider m_HealthSlider;
        [SerializeField] private IntEvent m_PlayerHealthChangeEvent;
        [SerializeField] private SOEvent m_PlayerDeathEvent;
        [SerializeField] private int m_MaxHealth;

        private int m_Health = default;

        private void Awake()
        {
            m_HealthSlider.maxValue = m_MaxHealth;
            m_HealthSlider.value = m_MaxHealth;
            m_Health = m_MaxHealth;
            m_PlayerHealthChangeEvent.Register(ModifyHealth);
        }

        private void OnDestroy()
        {
            m_PlayerHealthChangeEvent.Unregister(ModifyHealth);
        }

        private void ModifyHealth()
        {
            m_Health += m_PlayerHealthChangeEvent.value;
            m_HealthSlider.value = m_Health;

            if(m_PlayerHealthChangeEvent.value < 0)
                Instantiate(m_PlayerExplosion, transform.position, transform.rotation);
            
            if (m_Health <= 0)
            {
                m_PlayerDeathEvent.Raise();
                Destroy(m_Player);
            }
        }
    }
}