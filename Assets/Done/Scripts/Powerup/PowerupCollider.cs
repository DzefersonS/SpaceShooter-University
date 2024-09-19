using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class PowerupCollider : MonoBehaviour
    {
        [SerializeField] private PlayerEvent m_PowerupActivateEventSO;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_PowerupActivateEventSO.Raise();
                Destroy(gameObject);
            }
        }
    }
}