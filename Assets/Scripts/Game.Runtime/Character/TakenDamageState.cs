using System.Collections;
using UnityEngine;

namespace Game.Runtime.Character
{
    public class TakenDamageState : CharacterState
    {
        public override IEnumerator Start()
        {
            this.characterCombatController.ActionTakenDamage();
            yield break;
        }

        public override IEnumerator TakenDamage()
        {
            this.characterCombatController.ActionTakenDamage();
            yield break;
        }
    }
}