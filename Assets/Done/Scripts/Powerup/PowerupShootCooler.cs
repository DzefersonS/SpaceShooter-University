using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PowerupShootCooler : Powerup
    {
        [SerializeField] private float m_Duration;

        private Player m_Player = default;
        private float m_TimeRemaining = 0.0f;

        private void Awake()
        {
            enabled = false;
        }

        public override void Activate(Player player)
        {
            m_TimeRemaining = m_Duration;
            if (enabled)
                return;

            m_Player = player;
            enabled = true;
            m_Player.ShootPowerup(true);
        }

        private void Update()
        {
            m_TimeRemaining -= Time.deltaTime;
            if (m_TimeRemaining < 0.0f)
            {
                enabled = false;
                m_Player.ShootPowerup(false);
            }
        }
    }
}
