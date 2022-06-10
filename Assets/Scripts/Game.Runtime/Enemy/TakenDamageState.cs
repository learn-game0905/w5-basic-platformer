using System.Collections;

namespace Game.Runtime.Enemy
{
    public class TakenDamageState : EnemyState
    {
        public override IEnumerator Start()
        {
            this.enemyCombatController.ActionTakenDamage();
            yield break;
        }

        public override IEnumerator TakenDamage()
        {
            this.enemyCombatController.ActionTakenDamage();
            yield break;
        }
    }
}