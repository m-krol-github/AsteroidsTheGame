using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events 
{
    [System.Serializable]
    public class EventsManager
    {
        public GameEvents MainEvents { get; } = new GameEvents();
        public UiEvents UiEvents { get; } = new UiEvents();
    }
}