using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Utils;

namespace Asteroids
{
    public class Asteroid : MonoBehaviour, IDestroyable
    {
        public float collisionSpeed = 50;
        public float asteroidSpeeed;
        public Vector3 direction;

        [Header("PowerUPs")]
        public PowerUp healthUP;
        public PowerUp shootUP;

        [Header("Chunks"), SerializeField]
        private Chunk[] chunks;

        private CoreManager core;

        public void InitAsteroid(CoreManager core)
        {
            this.gameObject.transform.parent = core.GameManager.spawnsHolder.transform;

            this.core = core;
        }

        public void DestroyMe()
        {
            Destroy(this.gameObject);
        }

        private void Update()
        {
            if (this.gameObject.GetComponent<Rigidbody2D>().IsAwake())
            {
                transform.position = Vector3.MoveTowards(transform.position, direction, asteroidSpeeed * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Bullet")
            {
                var propability = Random.Range(0, 100);

                if (propability < 10)
                    Instantiate(healthUP, this.gameObject.transform.position, transform.rotation);

                if (propability > 95)
                    Instantiate(shootUP, this.gameObject.transform.position, transform.rotation);

                //
                var afterCollisionL = Instantiate(chunks[0], this.gameObject.transform.position, transform.rotation);
                var afterCollisionR = Instantiate(chunks[1], this.gameObject.transform.position, transform.rotation);
                afterCollisionL.OnInitChunk(core);
                afterCollisionR.OnInitChunk(core);

                core.Events.MainEvents.AsteroidHitCallback(10);

                other.gameObject.GetComponent<IDestroyable>().DestroyMe();
            }

            if (other.gameObject.tag == "Player")
            {
                core.Events.MainEvents.PlayerHitCallback();
            }

            if(other.gameObject.tag == "Shield")
            {
                var afterCollisionL = Instantiate(chunks[0], this.gameObject.transform.position, transform.rotation);
                var afterCollisionR = Instantiate(chunks[1], this.gameObject.transform.position, transform.rotation);
                afterCollisionL.OnInitChunk(core);
                afterCollisionR.OnInitChunk(core);

                core.Events.MainEvents.AsteroidHitCallback(10);
            }
            /*
            if(other.gameObject.tag == "Asteroid")
            {
                int dirX = Random.Range(-1, 1);
                int dirY = Random.Range(-1, 1);
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirX, dirY) * collisionSpeed * Time.deltaTime);
            }*/
        }

    }
}