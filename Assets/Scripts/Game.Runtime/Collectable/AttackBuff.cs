using Game.Runtime.Character;
using UnityEngine;

namespace Game.Runtime.Collectable
{
    public class AttackBuff : Collectable
    {
        public float value;

        protected override bool Collect(Collider2D other)
        {
            ColliderDictionary.CharacterStatsControllers.TryGetValue(other, out CharacterStatsController characterStatsController);
            if (characterStatsController == null) return false;
            characterStatsController.AttackBuff(value);
            return true;
        }
    }
}