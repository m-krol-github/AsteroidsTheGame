using UnityEngine;
using Player;
using Asteroids;
using Utils;
using Events;
using Sounds;
using Core.UI;
using Enemies;

namespace Core
{
    public class CoreManager : MonoBehaviour
    {
        [SerializeField]
        private EventsManager events;
        public EventsManager Events => events;

        [SerializeField]
        private GameManager gameManager;
        public GameManager GameManager => gameManager;

        [SerializeField]
        private PlayerManager player;
        public PlayerManager Player => player;

        [SerializeField]
        private Enums enums;
        public Enums Enums => enums;

        [SerializeField]
        private SoundsManage sounds;
        public SoundsManage Sounds => sounds;

        [SerializeField]
        private AsteroidsSpawners asteroidsSpawners;
        public AsteroidsSpawners AsteroidsSpawners => asteroidsSpawners;

        [SerializeField]
        private UiRoot uiRoot;
        public UiRoot UiRoot => uiRoot;

        [SerializeField]
        private EnemySpawner enemySpawner;
        public EnemySpawner EnemySpawner => enemySpawner;
    }
}