using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Asteroids;
using Utils;
using Events;
using Sounds;

namespace Core
{
    public class CoreManager : MonoBehaviour
    {
        [SerializeField]
        private GameEvents events;
        public GameEvents Events => events;

        [SerializeField]
        private GameManager gameManager;
        public GameManager GameManager => gameManager;

        [SerializeField]
        private PlayerManager player;
        public PlayerManager Player => player;

        [SerializeField]
        private AsteroidsManager asteroids;
        public AsteroidsManager Asteroids => asteroids;

        [SerializeField]
        private Enums enums;
        public Enums Enums => enums;

        [SerializeField]
        private SoundsManage sounds;
        public SoundsManage Sounds => sounds;

        [SerializeField]
        private AsteroidsSpawners asteroidsSpawners;
        public AsteroidsSpawners AsteroidsSpawners => asteroidsSpawners;
    }
}