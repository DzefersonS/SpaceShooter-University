using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(fileName = "Player Inputs SO", menuName = "Create New Player Inputs SO")]
    public class PlayerInputsSO : ScriptableObject
    {
        public KeyCode moveForward;
        public KeyCode moveBackward;
        public KeyCode moveLeft;
        public KeyCode moveRight;
        public KeyCode shoot;
    }
}