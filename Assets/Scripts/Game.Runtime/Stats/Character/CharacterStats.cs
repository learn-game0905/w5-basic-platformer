using UnityEngine;

namespace Game.Runtime.Stats.Character
{
    [CreateAssetMenu(menuName = "Stats/CharacterStats", fileName = "New Stats")]
    public class CharacterStats : ScriptableObject
    {
        public float attack;
        public float attackRange;
        public float health;
        public float maxHealth;
        public float moveSpeed;
    }
}
