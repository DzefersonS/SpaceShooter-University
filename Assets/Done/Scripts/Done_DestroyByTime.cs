using UnityEngine;

namespace SpaceShooter
{
    public class Done_DestroyByTime : MonoBehaviour
    {
        public float lifetime;

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }
    } //class Done_DestroyByTime
} //namespace SpaceShooter