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

        public UnityAction onHealthPick;
        public void HealthPickUP()
        {
            onHealthPick.Invoke();
        }

        public UnityAction onShootPick;
        public void ShootPickUp()
        {
            onShootPick.Invoke();
        }

        public UnityAction onEnemySpawn;
        public void EnemySpawnCallback()
        {
            onEnemySpawn.Invoke();
        }

        public UnityAction onEnemyHitBasic;
        public UnityAction<int> onEnemyHit;
        public void EnemyHitCallBack(int i)
        {
            onEnemyHit.Invoke(i);
        }

        public void EnemyHitBasicCallback()
        {
            onEnemyHitBasic.Invoke();
        }

    }
}