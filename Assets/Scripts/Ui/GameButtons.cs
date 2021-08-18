using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Events;
using Core;
using Utils;
using UnityEngine.Events;

namespace Core.UI
{
    public class GameButtons : BaseView
    {
        [SerializeField]
        private Button playButton;

        private CoreManager core;

        private UnityAction onPlayClick;

        public void InitView(CoreManager core)
        {
            this.core = core;
            this.playButton.onClick.AddListener(PlayClickCallback);

            Values.UiValues.buttonsInit = true;
        }

        public void UpdateView()
        {

        }


        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }

        public void PlayClickCallback()
        {
            core.Events.UiEvents.GameStartCallback();
        }
    }
}