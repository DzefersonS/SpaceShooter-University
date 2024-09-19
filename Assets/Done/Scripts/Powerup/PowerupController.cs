using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class PowerupController : MonoBehaviour
    {
        [SerializeField] private Powerup[] m_Powerups;
        [SerializeField] private SOEvent m_PowerupActivateEventSO;

        private void Awake()
        {
            m_PowerupActivateEventSO.Register(ActivateRandomPowerup);
        }

        private void OnDestroy()
        {
            m_PowerupActivateEventSO.Unregister(ActivateRandomPowerup);
        }

        private void ActivateRandomPowerup()
        {
            int randomPowerupIndex = Random.Range(0, m_Powerups.Length - 1);
            m_Powerups[randomPowerupIndex].Activate();
        }
    }
}