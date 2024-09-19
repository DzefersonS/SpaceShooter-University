using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpaceShooter
{
    public class PowerupCollider : MonoBehaviour
    {
        [SerializeField] private SOEvent m_ActivatePowerupEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_ActivatePowerupEvent.Raise();
                Destroy(gameObject);
            }
        }
    }
}