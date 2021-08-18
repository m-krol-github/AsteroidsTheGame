using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Utils;

namespace Enemies
{
    public class Enemy : MonoBehaviour,IDestroyable
    {
        public Vector2[] direction;
        public Vector3 currentDir;

        public float thisSpeed;
        public float timer = 1;

        public float Xmin;
        public float Ymin;
        public float Xmax;
        public float Ymax;

        [Header("PowerUPs")]
        public PowerUp healthUP;
        public PowerUp shootUP;

        private CoreManager core;


        public void InitEnemy(CoreManager core)
        {
            this.gameObject.transform.parent = core.GameManager.spawnsHolder.transform;

            this.core = core;

            StartCoroutine(SpeedUp());
        }

        // Update is called once per frame
        void Update()
        {
            var boundsX = Mathf.Clamp(transform.position.x, Xmin, Xmax);
            var boundsY = Mathf.Clamp(transform.position.y, Ymin, Ymax);

            if (transform.position.x < Xmin)
                transform.position = new Vector2(Xmax,transform.position.y);

            if (transform.position.x > Xmax)
                transform.position = new Vector2(Xmin, transform.position.y);

            if (transform.position.y < Ymin)
                transform.position = new Vector2(transform.position.x, Ymax);

            if (transform.position.y > Ymax)
                transform.position = new Vector2(transform.position.x, Ymin);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                var dir = Random.Range(0, direction.Length);
                currentDir = direction[dir];
                timer = 1;
            }

            MoveForward();
        }
        private void MoveForward()
        {
            transform.Translate(currentDir * thisSpeed * Time.deltaTime);
            //transform.position += Time.deltaTime * thisSpeed * currentDir;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "Player" && other.gameObject.tag != "Asteroid")
            {
                other.gameObject.GetComponent<IDestroyable>().DestroyMe();
                core.Events.MainEvents.EnemyHitCallBack(250);
                core.Events.MainEvents.EnemyHitBasicCallback();
            }

            if (other.gameObject.tag == "Player")
            {
                core.Events.MainEvents.EnemyHitBasicCallback();
                core.Events.MainEvents.PlayerHitCallback();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player" && other.gameObject.tag != "Asteroid")
            {
                other.gameObject.GetComponent<IDestroyable>().DestroyMe();
                core.Events.MainEvents.EnemyHitCallBack(250);
                core.Events.MainEvents.EnemyHitBasicCallback();
                DestroyMe();
            }

            if (other.gameObject.tag == "Player")
            {
                core.Events.MainEvents.EnemyHitBasicCallback();
                core.Events.MainEvents.PlayerHitCallback();
            }
        }

        private IEnumerator SpeedUp()
        {
            yield return new WaitForSeconds(.1f);
            thisSpeed = 5;
        }

        public void DestroyMe()
        {
            Destroy(this.gameObject);
        }
    }
}