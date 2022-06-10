using UnityEngine;

namespace Game.Runtime
{
    public class HealthBarRenderer : MonoBehaviour
    {
        [SerializeField] private Transform background;
        [SerializeField] private Transform health;

        public void Render(float value, float maxValue)
        {
            Vector3 scale = this.health.localScale;
            scale.x = value / maxValue;
            this.health.localScale = scale;
        }
    }
}