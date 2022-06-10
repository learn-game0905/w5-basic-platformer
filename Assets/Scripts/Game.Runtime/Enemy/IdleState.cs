using System.Collections;

namespace Game.Runtime.Enemy
{
    public class IdleState : EnemyState
    {
        public override IEnumerator Start()
        {
            this.enemyController.Idle();
            yield break;
        }
        
        public override IEnumerator Walk()
        {
            this.enemyStateMachine.SetState(new WalkState());
            yield break;
        }

        public override IEnumerator Attack()
        {
            this.enemyStateMachine.SetState(new AttackState());
            yield break;
        }
        public override IEnumerator TakenDamage()
        {
            this.enemyStateMachine.SetState(new TakenDamageState());
            yield break;
        }
    }
}