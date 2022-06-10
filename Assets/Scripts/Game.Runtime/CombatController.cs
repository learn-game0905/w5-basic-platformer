using UnityEngine;

namespace Game.Runtime
{
    public abstract class CombatController:MonoBehaviour
    {
        private Collider2D _collider2D;
        protected virtual void Start()
        {
            this._collider2D = GetComponent<Collider2D>();
            ColliderDictionary.AddCombatController(this._collider2D, this);
        }

        public abstract void Hit();
        public abstract void TakenDamage(float damage);
        public abstract void Death();
        protected virtual void OnDestroy()
        {
            ColliderDictionary.RemoveCombatController(this._collider2D);
        }
    }
}