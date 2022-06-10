using System.Collections;

namespace Game.Runtime.Enemy
{
    public class WalkState : EnemyState
    {
        public override IEnumerator Start()
        {
            this.enemyController.Move();
            yield break;
        }

        public override IEnumerator Idle()
        {
            this.enemyStateMachine.SetState(new IdleState());
            yield break;
        }

        public override IEnumerator Walk()
        {
            this.enemyController.Move();
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