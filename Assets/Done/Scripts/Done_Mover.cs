﻿using UnityEngine;

namespace SpaceShooter
{
    public class Done_Mover : MonoBehaviour
    {
        public float speed;

        private void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
}