using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Player;
using Asteroids;
using Sounds;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CoreManager core;
        public CoreManager Core => core;

        public GameObject spawnsHolder;

        private PlayerManager players;
        private Enums enums;
        private SoundsManage sounds;
        private AsteroidsSpawners asteroidsSpawners;

        private void Awake()
        {
            this.enums = core.Enums;
            #region ENUMS_ASSIGN

            if (enums.debugMode == Enums.DEBUG_MODE.YES)
            {
                Values.GameValues.isDebug = true;
            }else 
            if(enums.debugMode == Enums.DEBUG_MODE.NO)
            {
                Values.GameValues.isDebug = false;
            }

            if (enums.screenSleep == Enums.SCREEN_SLEEP.NEVER)
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }else 
            if(enums.screenSleep == Enums.SCREEN_SLEEP.NORMAL)
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }

            #endregion
            this.players = core.Player;
            this.sounds = core.Sounds;
            this.asteroidsSpawners = core.AsteroidsSpawners;
        }

        private void Start()
        {
            players.PlayerManagerInit(core);
            sounds.InitSounds(core);
            asteroidsSpawners.InitSpaweners(core);
        }

        private void Update()
        {
            if(Values.GameValues.playerManagerInit)
                players.UpdatePlayersManager();

            if (Values.GameValues.isDebug)
            {
                if(Input.GetButtonDown("Cancel"))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            asteroidsSpawners.UpdateSpawner();
        }
    }
}