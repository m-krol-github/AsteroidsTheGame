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
        [Header("Player Properities")]
        [HideInInspector]
        public int playerHP = 3;
        public int playerScore;

        public PlayerShip playerShip;

        [SerializeField]
        private Animator playerAnimations;
        [SerializeField]
        private Animation playerDestorAnimation;
        [SerializeField]
        private Animation playerSpawnAnimation;
        [SerializeField]
        private Animation playerShieldAnimation;

        [SerializeField]
        private PlayerShip playerPrefab;

        private CoreManager core;
        private GameManager gameManager;
        private EventsManager events;

        public void PlayerManagerInit(CoreManager core)
        {
            this.core = core;
            this.events = core.Events;
            this.gameManager = core.GameManager;
            //
            playerScore = 0;
            //
            AssignEvents();

            Values.GameValues.playerManagerInit = true;
        }

        public void AssignEvents()
        {
            events.MainEvents.onAsteroidHit += AddScore;
            events.MainEvents.onPlayerHit += PlayerGotHit;
            events.UiEvents.onPlayClick += SpawnPlayer;
        }

        public void SpawnPlayer()
        {
            StartCoroutine(SpawnPlayerShip());
        }

        public void UpdatePlayersManager()
        {
            if (Input.GetButtonDown("Submit"))
                SpawnPlayer();  

            if (Values.GameValues.playerSpawned)
            {
                if (playerHP <= 0)
                {
                    StartCoroutine(DestoryShip());
                }
            }

            PlayerPrefs.SetInt("Score", playerScore);
            if(PlayerPrefs.GetInt("Score") <= playerScore)
            {
                PlayerPrefs.SetInt("TopScore", playerScore);
            }
        }

        public void ShootCallback()
        {
            Debug.Log("Shooot");
            events.MainEvents.PlayerShootSound();
        }

        public void PlayerGotHit()
        {
            playerHP--;
        }

        private IEnumerator SpawnPlayerShip()
        {
            playerHP = core.GameManager.playerLifes;
            yield return null;
            var player = Instantiate(playerPrefab);
            playerShip = player;
            playerAnimations = playerShip.gameObject.GetComponent<Animator>();
            playerShip.transform.localPosition = new Vector3(0, 0, 0);
            playerShip.InitPlayers(core, ShootCallback);
        }

        public void AddScore(int score)
        {
            playerScore += score;
        }

        private void UnAssignEvents()
        {
            events.MainEvents.onAsteroidHit -= AddScore;
            events.MainEvents.onPlayerHit -= PlayerGotHit;
            events.UiEvents.onPlayClick -= SpawnPlayer;
        }

        private void OnDestroy()
        {
            Debug.Log("UNAssign");
            UnAssignEvents();
        }

        private IEnumerator DestoryShip()
        {
            Values.GameValues.playerSpawned = false;
            playerAnimations.SetBool("Destroy", true);
            yield return new WaitForSeconds(1);
            Destroy(playerShip.gameObject);
        }

    }
}