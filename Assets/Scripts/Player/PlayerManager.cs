using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Events;
using Sounds;
using Utils;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerShip playerShip;

        private CoreManager core;
        private GameEvents events;

        public void PlayerManagerInit(CoreManager core)
        {
            this.core = core;
            this.events = core.Events;
            //
            Values.GameValues.playerManagerInit = true;            

            playerShip.InitPlayers(core, ShootCallback);
        }


        public void UpdatePlayersManager()
        {
            playerShip.UpdatePlayerShip();
        }

        public void ShootCallback()
        {
            Debug.Log("Shooot");
            events.PlayerShootSound();
        }
    }
}