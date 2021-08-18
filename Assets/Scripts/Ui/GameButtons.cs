using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using TMPro;

namespace Core.UI
{
    public class GameButtons : BaseView
    {
        [SerializeField]
        private Button playButton;

        [SerializeField]
        private TextMeshProUGUI startGameText;

        private CoreManager core;

        public void InitView(CoreManager core)
        {
            this.core = core;
            this.playButton.onClick.AddListener(PlayClickCallback);
            //
            Values.UiValues.buttonsInit = true;
        }

        public void UpdateView()
        {
            if (Values.GameValues.playerSpawned)
            {
                playButton.gameObject.SetActive(false);
            }
            else
            {
                playButton.gameObject.SetActive(true);
            }
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