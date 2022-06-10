using Game.Runtime.Stats.Character;
using UnityEngine;

namespace Game.Runtime.Enemy
{
    public class EnemyStatsController : MonoBehaviour
    {
        [SerializeField] private EnemyStats stats;
        [SerializeField] private HealthBarRenderer healthBarRenderer;
        public EnemyStats Stats => this.stats;

        private void Start()
        {
            this.stats = Instantiate(this.stats);
            this.stats.health = this.stats.maxHealth;
        }

        public bool TakenDamage(float damage)
        {
            if (this.stats.health - damage < 0) return true;
            this.stats.health -= damage;
            this.healthBarRenderer.Render(this.stats.health, this.stats.maxHealth);
            return this.stats.health <= 0;
        }
    }
}
