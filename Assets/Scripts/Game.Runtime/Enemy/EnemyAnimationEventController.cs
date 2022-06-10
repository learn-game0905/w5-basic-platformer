using System;
using UnityEngine;

namespace Game.Runtime.Enemy
{
    public class EnemyAnimationEventController : MonoBehaviour
    {
        private Action _attackEvent;
        private Action _hurtEvent;
        public void AddAttackEvent(Action attackEvent)
        {
            this._attackEvent += attackEvent;
        }
        private void Attack()
        {
            this._attackEvent?.Invoke();
        }

        public void AddHurtEvent(Action hurtEvent)
        {
            this._hurtEvent += hurtEvent;
        }
        private void EndHurt()
        {
            this._hurtEvent?.Invoke();
        }
    }
}
