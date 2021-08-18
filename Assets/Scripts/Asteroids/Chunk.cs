using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Asteroids
{
    public class Chunk : MonoBehaviour,IDestroyable
    {
        public float speed;
        public float deathCount = 5;
         

        private Vector3 movement;

        private CoreManager core;

        public void DestroyMe()
        {
            Destroy(this.gameObject);
        }

        public void OnInitChunk(CoreManager core)
        {
            this.core = core;
            this.gameObject.transform.parent = core.GameManager.spawnsHolder.transform;

            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        private void Update()
        {            
            if(deathCount <= 0)
            {
                Destroy(this.gameObject);
            }

            MoveForward();
        }

        private void MoveForward()
        {
            transform.position += Time.deltaTime * speed * movement;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "Player")
            {
                other.gameObject.GetComponent<IDestroyable>().DestroyMe();
                core.Events.MainEvents.AsteroidHitCallback(50);
            }

            if(other.gameObject.tag == "Player")
            {
                core.Events.MainEvents.PlayerHitCallback();
            }
        }

    }
}