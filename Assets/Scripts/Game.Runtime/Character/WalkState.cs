using System.Collections;
using UnityEngine;

namespace Game.Runtime.Character
{
    public class WalkState : CharacterState
    {
        public override IEnumerator Start()
        {
            this.characterController.Move();
            yield break;
        }

        public override IEnumerator Idle()
        {
            this.characterStateMachine.SetState(new IdleState());
            yield break;
        }

        public override IEnumerator Walk()
        {
            this.characterController.Move();
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