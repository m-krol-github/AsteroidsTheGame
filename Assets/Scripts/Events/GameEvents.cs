using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        public UnityAction onPlayerShooting;
        public void PlayerShootSound()
        {
            onPlayerShooting.Invoke();
        }

        public UnityAction onAsteroidHit;
        public void AsteroidHitCallback()
        {
            onAsteroidHit.Invoke();
        }
    }
}