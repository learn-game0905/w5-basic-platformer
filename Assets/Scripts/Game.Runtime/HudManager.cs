using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime
{
    public class HudManager : MonoBehaviour
    {
        private static HudManager instance;
        public static HudManager Instance => instance;

        private void Awake()
        {
            if (instance != null) return;
            instance = this;
        }

        [SerializeField] private Text txtAttack;
        [SerializeField] private Text txtJumpHeight;

        public void RenderAttack(float attack)
        {
            this.txtAttack.text = attack.ToString();
        }
        public void RenderJumpHeight(float jumpHeight)
        {
            this.txtJumpHeight.text = jumpHeight.ToString();
        }
        
    }
}
