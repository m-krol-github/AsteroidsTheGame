using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class UiRoot : MonoBehaviour
    {
        [SerializeField]
        private TopView topView;
        public TopView TopView => topView;

        [SerializeField]
        private GameButtons buttons;
        public GameButtons Buttons => buttons;
    }
}