using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Utils;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        public float interval = 15;

        [Header("Enemy"), SerializeField]
        private Enemy[] enemy;

        [SerializeField]
        private Collider[] areas;

        [SerializeField]
        private Collider selectedCollider;

        [SerializeField]
        private Vector2 dir;

        [Header("PowerUPs"), SerializeField]
        private PowerUp health;
        [SerializeField]
        private PowerUp shooting;

        private CoreManager core;

        public void InitSpaweners(CoreManager core)
        {
            this.core = core;

            Values.GameValues.enemysSpawnerReady = true;
        }

        public void UpdateSpawner()
        {
            interval -= Time.deltaTime;

            if (interval <= 0)
            {
                SpawnEnemy();
                interval = 15;
            }
        }

        private void SpawnEnemy()
        {
            //
            core.Events.MainEvents.EnemySpawnCallback();

            ///spawnPos
            var pickCol = Random.Range(0, areas.Length);
            selectedCollider = areas[pickCol];

            var pickPosX = Random.Range(selectedCollider.bounds.min.x, selectedCollider.bounds.max.x);
            var pickPosY = Random.Range(selectedCollider.bounds.min.y, selectedCollider.bounds.max.y);

            var pickPlace = new Vector3(pickPosX, pickPosY, 0);

            //spawn asteroid
            var enemyType = Random.Range(0, enemy.Length);
            var pickedEnemy = Instantiate(enemy[enemyType], pickPlace, Quaternion.identity);
            pickedEnemy.InitEnemy(core);
            pickedEnemy.healthUP = health;
            pickedEnemy.shootUP = shooting;

        }
    }
}