using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Asteroids
{
    public class AsteroidsSpawners : MonoBehaviour
    {
        public float interval = 3;

        [SerializeField]
        private Asteroid asteroid;

        [SerializeField]
        private Collider[] areas;

        private CoreManager core;


        public void InitSpaweners(CoreManager core)
        {
            this.core = core;

        }

        public void UpdateSpawner()
        {
            interval -= Time.deltaTime;


            if (interval <= 0)
            {
                SpawnAsteroid();
                interval = 3;
            }
        }

        private void SpawnAsteroid()
        {
            float area1 = Random.Range(areas[0].bounds.min.x, areas[0].bounds.max.x);
            float area2 = Random.Range(areas[1].bounds.min.x, areas[1].bounds.max.x);
            float area3 = Random.Range(areas[2].bounds.min.y, areas[2].bounds.max.y);
            float area4 = Random.Range(areas[3].bounds.min.y, areas[3].bounds.max.y);

            var whereA = Random.Range(area1, area2);
            var whereB = Random.Range(area3, area4);

            var where = Random.Range(whereA, whereB);

            Instantiate(asteroid, new Vector3(where,where,where), Quaternion.identity);
        }

        private Vector3 GetSpawnPosition(GameObject area)
        {
            Vector3 scale = area.transform.localScale;

            float x = area.transform.position.x + Random.Range(-scale.x / 2, scale.x / 2);
            float y = area.transform.position.y + Random.Range(-scale.y / 2, scale.y / 2);

            Vector3 location = new Vector3(x, y, 0);

            return location;
        }
    }
}