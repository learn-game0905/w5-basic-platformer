using UnityEngine;

namespace Game.Runtime
{
    public class Water : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!ColliderDictionary.CombatControllers.TryGetValue(other, out CombatController combatController)) return;
            combatController.Death();
        }
    }
}
