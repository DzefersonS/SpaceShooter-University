using UnityEngine;

namespace SpaceShooter
{
    public class PowerupIncreaseSpeed : Powerup
    {
        [SerializeField] private float m_PowerupDuration;
        [SerializeField] private float m_NewSpeed;

        private Player m_Player = default;
        private float m_TimeRemaining = default;
        private float m_PlayerMovementSpeed = default;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            m_TimeRemaining -= Time.deltaTime;
            if (m_TimeRemaining <= 0.0f)
            {
                m_Player.speed = m_PlayerMovementSpeed;
                enabled = false;
            }
        }

        public override void Activate(Player player)
        {
            if (enabled)
            {
                m_TimeRemaining = m_PowerupDuration;
                return;
            }

            m_Player = player;
            enabled = true;
            m_TimeRemaining = m_PowerupDuration;
            m_PlayerMovementSpeed = player.speed;
            player.speed = m_NewSpeed;
        }
    }
}