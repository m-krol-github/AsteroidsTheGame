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

        public UnityAction onAsteroidHitBasic;
        public UnityAction<int> onAsteroidHit;
        public void AsteroidHitCallback(int i)
        {
            onAsteroidHitBasic.Invoke();
            onAsteroidHit.Invoke(i);
        }

        public UnityAction onPlayerMove;
        public void EngineSoundCallback()
        {
            onPlayerMove.Invoke();
        }

        public UnityAction onPlayerHit;
        public void PlayerHitCallback()
        {
            onPlayerHit.Invoke();
        }
    }
}