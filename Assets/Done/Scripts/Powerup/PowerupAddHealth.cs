using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class PowerupAddHealth : Powerup
    {
        public override void Activate(Player player)
        {
            player.ModifyHealth(1);
        }
    }
}