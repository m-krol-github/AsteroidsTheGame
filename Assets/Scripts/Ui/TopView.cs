using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;
using Utils;

namespace Core.UI
{
    public class TopView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI score;

        [SerializeField]
        private TextMeshProUGUI topScore;

        [SerializeField]
        private TextMeshProUGUI health;


        private CoreManager core;

        public void InitView(CoreManager core)
        {
            this.core = core;

            Values.UiValues.topInit = true;
        }

        public void UpdateView()
        {
            this.topScore.text = core.GameManager.topScore.ToString();
            this.score.text = core.Player.playerScore.ToString();
            this.health.text = core.Player.playerHP.ToString();
        }

        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }
    }
}