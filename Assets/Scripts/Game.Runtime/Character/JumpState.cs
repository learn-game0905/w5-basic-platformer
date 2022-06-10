using System.Collections;

namespace Game.Runtime.Character
{
    public class JumpState : CharacterState
    {
        public override IEnumerator Start()
        {
            this.characterController.Jump();
            yield break;
        }

        public override IEnumerator Idle()
        {
            if (!this.characterController.IsGround()) yield break;
            yield return base.Idle();
        }

        public override IEnumerator Jump()
        {
            this.characterController.Jump();
            yield break;
        }
    }
}