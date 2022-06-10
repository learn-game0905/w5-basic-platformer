using System.Collections;
using UnityEngine;

namespace Game.Runtime.Character
{
    public class AttackState : CharacterState
    {

        public override IEnumerator Start()
        {
            this.characterController.Attack();
            yield break;
        }

        public override IEnumerator Idle()
        {
            yield break;
        }

        public override IEnumerator Walk()
        {
            yield break;
        }

        public override IEnumerator Attack()
        {
            yield break;
        }

        public override IEnumerator Jump()
        {
            yield break;
        }
        public override IEnumerator TakenDamage()
        {
            this.characterStateMachine.SetState(new TakenDamageState());
            yield break;
        }
        
    }
}