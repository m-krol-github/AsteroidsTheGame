using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Events;


namespace Sounds
{
    public class SoundsManage : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioS;

        [SerializeField]
        private AudioClip[] shootSounds;

        [SerializeField]
        private AudioClip[] asteroidHit;

        private CoreManager core;
        private GameEvents events;

        public void InitSounds(CoreManager core)
        {
            this.core = core;
            this.events = core.Events;

            AssignEvents();
        }

        private void AssignEvents()
        {
            events.onPlayerShooting += PlayShootSound;
            events.onAsteroidHit += PlayAsterHitSound;
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


















        private void UnAssignEvents()
        {
            events.onPlayerShooting -= PlayShootSound;
            events.onAsteroidHit -= PlayAsterHitSound;
        }

        private void OnDestroy()
        {
            Debug.Log("UNAssign");
            UnAssignEvents();
        }


    }
}