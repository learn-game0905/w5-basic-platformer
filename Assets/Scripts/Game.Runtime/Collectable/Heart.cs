using Game.Runtime.Character;
using UnityEngine;

namespace Game.Runtime.Collectable
{
    public class Heart : Collectable
    {
        public float value;

        protected override bool Collect(Collider2D other)
        {
            CharacterStatsController characterStatsController;
            ColliderDictionary.CharacterStatsControllers.TryGetValue(other, out characterStatsController);
            if (characterStatsController == null) return false;
            characterStatsController.Heal(value);
            return true;
        }
    }
}