using UnityEngine;

namespace Game.Runtime.Stats.Character
{
    [CreateAssetMenu(menuName = "Stats/EnemyStats", fileName = "New Stats")]
    public class EnemyStats : ScriptableObject
    {
        public float attack;
        public float attackRange;
        public float followRange;
        public float health;
        public float maxHealth;
        public float moveSpeed;
    }
}
