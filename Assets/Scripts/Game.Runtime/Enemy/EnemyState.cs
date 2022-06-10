using System.Collections;

namespace Game.Runtime.Enemy
{
    public class EnemyState
    {
        public EnemyStateMachine enemyStateMachine;
        public EnemyController enemyController;
        public EnemyCombatController enemyCombatController;

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Idle()
        {
            yield break;
        }

        public virtual IEnumerator Walk()
        {
            yield break;
        }

        public virtual IEnumerator Attack()
        {
            yield break;
        }

        public virtual IEnumerator TakenDamage()
        {
            yield break;
        }
    }
}