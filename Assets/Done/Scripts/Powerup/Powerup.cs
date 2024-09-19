using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public abstract class Powerup : MonoBehaviour
    {
        public abstract void Activate();
    }
}