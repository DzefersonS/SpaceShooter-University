using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpaceShooter
{
    [CreateAssetMenu(fileName = "Player Event SO", menuName = "Create New Player Event SO")]
    public class PlayerEvent : SOTypeEvent<Player>
    {
    }
}