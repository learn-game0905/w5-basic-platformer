using System;
using UnityEngine;

namespace Game.Runtime.Character
{
    public class CharacterAnimationEventController : MonoBehaviour
    {
        private Action _attackEvent;
        private Action _endAttackEvent;
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

        public void AddEndAttackEvent(Action endAttackEvent)
        {
            this._endAttackEvent += endAttackEvent;
        }

        private void EndAttack()
        {
            this._endAttackEvent?.Invoke();
        }
    }
}