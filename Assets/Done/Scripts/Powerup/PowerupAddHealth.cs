using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class PowerupAddHealth : Powerup
    {
        [SerializeField] private IntEvent m_PlayerHealthModifyEvent;

        public override void Activate()
        {
            m_PlayerHealthModifyEvent.value = 1;
        }
    }
}