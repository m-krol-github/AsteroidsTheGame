using Events;
using UnityEngine;
using Utils;
using Player;
using Asteroids;
using Sounds;
using UnityEngine.SceneManagement;
using Core.UI;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CoreManager core;
        public CoreManager Core => core;

        [Header("Game Properities")]
        public int playerLifes = 3;
        public int topScore;

        public GameObject spawnsHolder;

        //public PlayerShip playerShip;

        private PlayerManager players;
        private Enums enums;
        private SoundsManage sounds;
        private AsteroidsSpawners asteroidsSpawners;
        private EventsManager events;

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

            this.events = core.Events;
            this.players = core.Player;
            this.sounds = core.Sounds;
            this.asteroidsSpawners = core.AsteroidsSpawners;

            sounds.InitSounds(core);
        }

        private void Start()
        {
            Values.GameValues.gameStart = true;
            
            asteroidsSpawners.InitSpaweners(core);
            players.PlayerManagerInit(core);
            // init ui
            core.UiRoot.TopView.InitView(core);
            core.UiRoot.TopView.ShowView();
            core.UiRoot.Buttons.InitView(core);
            core.UiRoot.Buttons.ShowView();
        }

        private void Update()
        {
            topScore = PlayerPrefs.GetInt("TopScore");

            if (!Values.GameValues.gameStart)
            {
                if (Values.GameValues.gameStart)
                    return;

                if (Input.GetMouseButtonDown(2))
                {                   
                }
            }

            if(Values.GameValues.asteroidsSpawnerReady)
                asteroidsSpawners.UpdateSpawner();
            
            if (Values.GameValues.playerManagerInit)
                players.UpdatePlayersManager();
            
            
            if (Values.GameValues.playerSpawned)
            {
                players.playerShip.UpdatePlayerShip();
                core.Events.MainEvents.EngineSoundCallback();
            }
                

            if (Values.GameValues.isDebug)
            {
                if(Input.GetButtonDown("Cancel"))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


            if (Values.UiValues.topInit)
                core.UiRoot.TopView.UpdateView();
            /*
            if (Values.UiValues.buttonsInit)
                core.UiRoot.Buttons.UpdateView();*/
        }
    }
}