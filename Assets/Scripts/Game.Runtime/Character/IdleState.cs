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

        public override IEnumerator Idle()
        {
            yield break;
        }
    }
}