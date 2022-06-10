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