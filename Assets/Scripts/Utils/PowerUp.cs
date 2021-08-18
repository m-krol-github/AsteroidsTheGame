using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class PowerUp : MonoBehaviour
    {
        public float speed = 5;
        public float deathCount = 5;


        private Vector3 movement;
        public int powerUpType;

        private void Start()
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        private void Update()
        {
            if (deathCount <= 0)
            {
                Destroy(this.gameObject);
            }

            MoveForward();
        }

        private void MoveForward()
        {
            transform.position += Time.deltaTime * speed * movement;
        }

    }
}