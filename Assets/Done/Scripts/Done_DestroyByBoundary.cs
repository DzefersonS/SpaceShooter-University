using UnityEngine;

namespace SpaceShooter
{
    public class Done_DestroyByBoundary : MonoBehaviour
    {
        void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    } //class Done_DestroyByBoundary
} //namespace SpaceShooter