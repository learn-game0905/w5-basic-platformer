using UnityEngine;

namespace Game.Runtime
{
    public class StateManager : MonoBehaviour
    {
        private static StateManager instance;
        public static StateManager Instance => instance;
        
        [SerializeField] private GameReplayPanel gameReplayPanel;

        private void Awake()
        {
            if (instance != null) return;
            instance = this;
        }

        public void Win()
        {
            gameReplayPanel.Render("Victory");
        }

        public void Lose()
        {
            gameReplayPanel.Render("Defeated");
        }
    }
}