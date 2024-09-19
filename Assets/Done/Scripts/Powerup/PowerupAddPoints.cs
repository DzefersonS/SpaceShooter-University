using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class PowerupAddPoints : Powerup
    {
        [SerializeField] private int m_PointsToAdd;
        [SerializeField] private IntEvent m_ScoreAddEventSO;

        public override void Activate(Player player)
        {
            m_ScoreAddEventSO.value = m_PointsToAdd;
        }
    }
}