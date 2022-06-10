using System;
using Game.Runtime.Stats.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Runtime.Character
{
    public class CharacterStatsController : MonoBehaviour
    {
        [SerializeField] private CharacterStats stats;
        [SerializeField] private HealthBarRenderer healthBarRenderer;

        private Collider2D _collider2D;
        public CharacterStats Stats => this.stats;

        private void Start()
        {
            this._collider2D = GetComponent<Collider2D>();
            ColliderDictionary.AddCharacterStatsController(this._collider2D, this);
            this.stats = Instantiate(this.stats);
            this.stats.health = this.stats.maxHealth;
            RenderHealth();
            HudManager.Instance.RenderAttack(this.stats.attack);
            HudManager.Instance.RenderJumpHeight(this.stats.jumpHeight);
        }

        private void RenderHealth()
        {
            healthBarRenderer.Render(this.stats.health, this.stats.maxHealth);
        }
        
        public bool TakenDamage(float damage)
        {
            this.stats.health = this.stats.health - damage <= 0 ? 0 : this.stats.health - damage;
            RenderHealth();
            return this.stats.health <= 0;
        }

        public void Heal(float value)
        {
            if (this.stats.health + value >= this.stats.maxHealth)
            {
                this.stats.health = this.stats.maxHealth;
            }
            else
            {
                this.stats.health += value;
            }

            RenderHealth();
        }

        public void AttackBuff(float value)
        {
            this.stats.attack += value;
            HudManager.Instance.RenderAttack(this.stats.attack);
        }

        public void JumpBuff(float value)
        {
            this.stats.jumpHeight += value;
            HudManager.Instance.RenderJumpHeight(this.stats.jumpHeight);
        }

        private void OnDestroy()
        {
            ColliderDictionary.RemoveCharacterStatsController(this._collider2D);
        }
    }
}