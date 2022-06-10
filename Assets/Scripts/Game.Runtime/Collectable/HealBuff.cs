using Game.Runtime.Character;
using UnityEngine;

namespace Game.Runtime.Collectable
{
    public class HealBuff : Collectable
    {
        public float value;

        protected override bool Collect(Collider2D other)
        {
            ColliderDictionary.CharacterStatsControllers.TryGetValue(other, out CharacterStatsController characterStatsController);
            if (characterStatsController == null) return false;
            characterStatsController.Heal(value);
            return true;
        }
    }
}