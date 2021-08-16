using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Enums : MonoBehaviour
    {
        public enum DEBUG_MODE
        {
            YES,
            NO
        };

        public DEBUG_MODE debugMode;

        public enum SCREEN_SLEEP
        {
            NEVER,
            NORMAL
        };

        public SCREEN_SLEEP screenSleep;
        //

        public enum SCREEN_ORIENTATION
        {
            PORTRAIT,
            LANDSCAPE,
            AUTO
        };

        public SCREEN_ORIENTATION screenOrientation;
        //
    }
}