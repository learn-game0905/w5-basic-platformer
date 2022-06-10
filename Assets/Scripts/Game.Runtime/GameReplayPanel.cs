using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Runtime
{
    public class GameReplayPanel : MonoBehaviour
    {
        public Text txtState;
        public Button btnReplay;
        public CanvasGroup canvasGroup;

        private void Start()
        {
            SetVisible(false);
            this.btnReplay.onClick.AddListener(() => {
                SceneManager.LoadScene("Scene_01");
            });
        }

        private void SetVisible(bool visible)
        {
            this.canvasGroup.alpha = visible ? 1f : 0f;
            this.canvasGroup.interactable = visible;
        }

        public void Render(string state)
        {
            SetVisible(true);
            this.txtState.text = state;
        }
    }
}