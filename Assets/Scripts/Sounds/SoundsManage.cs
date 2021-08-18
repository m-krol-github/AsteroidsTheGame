using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Events;
using Utils;

namespace Sounds
{
    public class SoundsManage : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioS;

        [SerializeField]
        private AudioSource engineSourece;

        [SerializeField]
        private AudioClip engineSound;

        [SerializeField]
        private AudioClip[] shootSounds;

        [SerializeField]
        private AudioClip[] asteroidHit;

        [SerializeField]
        private AudioClip[] playerHit;

        [SerializeField]
        private AudioClip[] health;

        [SerializeField]
        private AudioClip[] shootUp;

        [SerializeField]
        private AudioClip[] enemySpawn;

        [SerializeField]
        private AudioClip[] enemyHit;




        private CoreManager core;
        private EventsManager events;

        public void InitSounds(CoreManager core)
        {
            this.core = core;
            this.events = core.Events;

            AssignEvents();

            PlayEngineSound();
        }

        private void AssignEvents()
        {
            events.MainEvents.onPlayerShooting += PlayShootSound;
            events.MainEvents.onAsteroidHitBasic += PlayAsterHitSound;
            events.MainEvents.onPlayerMove += StopEngineSound;
            events.MainEvents.onPlayerHit += PlayerHitSound;
            events.MainEvents.onHealthPick += PlayerHealthSound;
            events.MainEvents.onShootPick += ShootPickup;
            events.MainEvents.onEnemySpawn += EnemySpawn;
            events.MainEvents.onEnemyHitBasic += EnemyHit;
        }

        public void PlayShootSound()
        {
            var sound = Random.Range(0, shootSounds.Length);
            audioS.PlayOneShot(shootSounds[sound]);
        }

        public void PlayAsterHitSound()
        {
            var sound = Random.Range(0, asteroidHit.Length);
            audioS.PlayOneShot(asteroidHit[sound]);
        }

        public void PlayerHitSound()
        {
            var sound = Random.Range(0, playerHit.Length);
            audioS.PlayOneShot(playerHit[sound]);
        }

        public void PlayerHealthSound()
        {
            var sound = Random.Range(0, health.Length);
            audioS.PlayOneShot(health[sound]);
        }

        public void ShootPickup()
        {
            var sound = Random.Range(0, shootSounds.Length);
            audioS.PlayOneShot(shootSounds[sound]);
        }

        public void EnemySpawn()
        {
            var sound = Random.Range(0, enemySpawn.Length);
            audioS.PlayOneShot(enemySpawn[sound]);
        }

        public void EnemyHit()
        {
            var sound = Random.Range(0, enemyHit.Length);
            audioS.PlayOneShot(enemyHit[sound]);
        }


        public void PlayEngineSound()
        {
            engineSourece.Play();
        }

        public void StopEngineSound()
        {
            engineSourece.Stop();
        }

        private void UnAssignEvents()
        {
            events.MainEvents.onPlayerShooting -= PlayShootSound;
            events.MainEvents.onAsteroidHitBasic -= PlayAsterHitSound;
            events.MainEvents.onPlayerMove -= PlayEngineSound;
            events.MainEvents.onPlayerHit -= PlayerHitSound;
            events.MainEvents.onHealthPick -= PlayerHealthSound;
            events.MainEvents.onShootPick -= ShootPickup;
            events.MainEvents.onEnemySpawn -= EnemySpawn;
            events.MainEvents.onEnemyHitBasic -= EnemyHit;
        }

        private void OnDestroy()
        {
            Debug.Log("UNAssign");
            UnAssignEvents();
        }


    }
}