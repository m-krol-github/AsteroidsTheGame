using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Utils;

namespace Asteroids
{
    public class AsteroidsSpawners : MonoBehaviour
    {
        public float interval = 3;
        public float asteroidSpeeed;


        [SerializeField]
        private Asteroid[] asteroid;

        [SerializeField]
        private Collider[] areas;

        [SerializeField]
        private Collider selectedCollider;

        [SerializeField]
        private Vector2 dir;

        private CoreManager core;

        public void InitSpaweners(CoreManager core)
        {
            this.core = core;

            Values.GameValues.asteroidsSpawnerReady = true;
        }

        public void UpdateSpawner()
        {
            interval -= Time.deltaTime;

            if (interval <= 0)
            {
                SpawnAsteroid();
                interval = 1;
            }
        }

        private void SpawnAsteroid()
        {
            ///spawnPos
            var pickCol = Random.Range(0, areas.Length);
            selectedCollider = areas[pickCol];

            var pickPosX = Random.Range(selectedCollider.bounds.min.x, selectedCollider.bounds.max.x);
            var pickPosY = Random.Range(selectedCollider.bounds.min.y, selectedCollider.bounds.max.y);

            var pickPlace = new Vector3(pickPosX, pickPosY, 0);

            //spawn asteroid
            var asteroidType = Random.Range(0, asteroid.Length);
            var aster = Instantiate(asteroid[asteroidType], pickPlace, Quaternion.identity);
            aster.InitAsteroid(core);

            #region MOVE_DIRECTION

            if (selectedCollider == areas[0])
            {
                var roadTo = areas[1];

                var roadX = Random.Range(roadTo.bounds.min.x, roadTo.bounds.max.x);
                var roadY = Random.Range(roadTo.bounds.min.y, roadTo.bounds.max.y);

                var way = new Vector2(roadX, roadY);

                //give speed
                aster.asteroidSpeeed = asteroidSpeeed;

                //set direction
                aster.direction = way;
            }
            if (selectedCollider == areas[1])
            {
                var roadTo = areas[2];

                var roadX = Random.Range(roadTo.bounds.min.x, roadTo.bounds.max.x);
                var roadY = Random.Range(roadTo.bounds.min.y, roadTo.bounds.max.y);

                var way = new Vector2(roadX, roadY);

                //give speed
                aster.asteroidSpeeed = asteroidSpeeed;

                //set direction
                aster.direction = way;
            }
            if (selectedCollider == areas[2])
            {
                var roadTo = areas[3];

                var roadX = Random.Range(roadTo.bounds.min.x, roadTo.bounds.max.x);
                var roadY = Random.Range(roadTo.bounds.min.y, roadTo.bounds.max.y);

                var way = new Vector2(roadX, roadY);

                //give speed
                aster.asteroidSpeeed = asteroidSpeeed;

                //set direction
                aster.direction = way;
            }
            if (selectedCollider == areas[3])
            {
                var roadTo = areas[2];

                var roadX = Random.Range(roadTo.bounds.min.x, roadTo.bounds.max.x);
                var roadY = Random.Range(roadTo.bounds.min.y, roadTo.bounds.max.y);

                var way = new Vector2(roadX, roadY);

                //give speed
                aster.asteroidSpeeed = asteroidSpeeed;

                //set direction
                aster.direction = way;
            }

            #endregion

            //COMMENTED DUE TO LESSER EFFECTIVITY
            //

            /*
            //direction lottery                           
            var pickColl = Random.Range(0, areas.Length);
            var roadTo = areas[pickColl];

            var roadX = Random.Range(roadTo.bounds.min.x, roadTo.bounds.max.x);
            var roadY = Random.Range(roadTo.bounds.min.y, roadTo.bounds.max.y);

            var way = new Vector2(roadX, roadY);

            //give speed
            aster.asteroidSpeeed = asteroidSpeeed;

            //set direction
            aster.direction = way;*/
        }

    }
}