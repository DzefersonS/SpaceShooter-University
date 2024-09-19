using UnityEngine;

namespace SpaceShooter
{
    public class Done_DestroyByBoundary : MonoBehaviour
    {
        void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}