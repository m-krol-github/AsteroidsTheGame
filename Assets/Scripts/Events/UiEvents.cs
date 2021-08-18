using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class UiEvents : MonoBehaviour
    {
        public UnityAction onPlayClick;
        public void GameStartCallback()
        {
            onPlayClick.Invoke();
        }

        public UnityAction onPlayerSpawn;
        public void PlayerSpawnCallback()
        {
            onPlayerSpawn.Invoke();
        }
    }
}