using System.Collections;
using UnityEngine;

namespace Game.Runtime.Enemy
{
    public class AttackState : EnemyState
    {
        private bool isTakenDamge = false;
        public override IEnumerator Start()
        {
            float attackLength = this.enemyController.Attack();
            yield return new WaitForSeconds(attackLength);
            if (isTakenDamge) yield break;
            this.enemyStateMachine.SetState(new IdleState());
        }
        public override IEnumerator TakenDamage()
        {
            isTakenDamge = true;
            this.enemyStateMachine.SetState(new TakenDamageState());
            yield break;
        }
    }
}