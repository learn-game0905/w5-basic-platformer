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
        
        public override IEnumerator Walk()
        {
            this.characterController.Move();
            yield break;
        }

    }
}