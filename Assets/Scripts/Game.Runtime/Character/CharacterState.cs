using System.Collections;

namespace Game.Runtime.Character
{
    public class CharacterState
    {
        public CharacterStateMachine characterStateMachine;
        public CharacterController characterController;
        public CharacterCombatController characterCombatController;

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Idle()
        {
            this.characterStateMachine.SetState(new IdleState());
            yield break;
        }

        public virtual IEnumerator Walk()
        {
            this.characterStateMachine.SetState(new WalkState());
            yield break;
        }

        public virtual IEnumerator Attack()
        {
            this.characterStateMachine.SetState(new AttackState());
            yield break;
        }

        public virtual IEnumerator TakenDamage()
        {
            this.characterStateMachine.SetState(new TakenDamageState());
            yield break;
        }

        public virtual IEnumerator Jump()
        {
            this.characterStateMachine.SetState(new JumpState());
            yield break;
        }
    }
}