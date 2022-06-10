using System.Collections;
using UnityEngine;

namespace Game.Runtime.Character
{
    public class AttackState : CharacterState
    {
        private bool isTakenDamage = false;
        public override IEnumerator Start()
        {
            float attackLength = this.characterController.Attack();
            yield return new WaitForSeconds(attackLength);
            if (this.isTakenDamage) yield break;
            this.characterStateMachine.SetState(new IdleState());
        }
        public override IEnumerator TakenDamage()
        {
            this.isTakenDamage = true;
            this.characterStateMachine.SetState(new TakenDamageState());
            yield break;
        }
    }
}