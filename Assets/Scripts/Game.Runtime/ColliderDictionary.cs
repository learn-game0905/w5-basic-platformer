using System.Collections.Generic;
using Game.Runtime.Character;
using UnityEngine;

namespace Game.Runtime
{
    public static class ColliderDictionary
    {
        private static readonly Dictionary<Collider2D, CombatController> s_combatControllers =
            new Dictionary<Collider2D, CombatController>();

        private static readonly Dictionary<Collider2D, CharacterStatsController> s_characterStatsControllers =
            new Dictionary<Collider2D, CharacterStatsController>();

        public static Dictionary<Collider2D, CombatController> CombatControllers => s_combatControllers;

        public static Dictionary<Collider2D, CharacterStatsController> CharacterStatsControllers =>
            s_characterStatsControllers;
        public static void AddCombatController(Collider2D collider2D, CombatController combatController)
        {
            s_combatControllers.Add(collider2D, combatController);
        }

        public static void RemoveCombatController(Collider2D collider2D)
        {
            s_combatControllers.Remove(collider2D);
        }
        
        public static void AddCharacterStatsController(Collider2D collider2D, CharacterStatsController characterStatsController)
        {
            s_characterStatsControllers.Add(collider2D, characterStatsController);
        }

        public static void RemoveCharacterStatsController(Collider2D collider2D)
        {
            s_characterStatsControllers.Remove(collider2D);
        }
    }
}