using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Values : MonoBehaviour
    {
        public class GameValues
        {
            public static bool isDebug;
            public static bool gameStart;

            public static bool playerManagerInit;
            public static bool playerShipInit;
            public static bool asteroidsSpawnerReady;
            public static bool playerSpawned;

            public static bool asteroidInit;
            public static bool enemyInit;

            public static bool enemysSpawnerReady;
        }

        public class UiValues
        {
            public static bool topInit;
            public static bool buttonsInit;
        }
    }
}