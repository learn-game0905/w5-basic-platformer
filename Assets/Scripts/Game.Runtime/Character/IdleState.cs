using System.Collections;
using UnityEngine;

namespace Game.Runtime.Character
{
    public class IdleState : CharacterState
    {
        public override IEnumerator Start()
        {
            this.characterController.Idle();
            yield break;
        }
        
        public override IEnumerator Walk()
        {
            this.characterStateMachine.SetState(new WalkState());
            yield break;
        }

        public override IEnumerator Attack()
        {
            this.characterStateMachine.SetState(new AttackState());
            yield break;
        }
        public override IEnumerator TakenDamage()
        {
            this.characterStateMachine.SetState(new TakenDamageState());
            yield break;
        }
    }
}