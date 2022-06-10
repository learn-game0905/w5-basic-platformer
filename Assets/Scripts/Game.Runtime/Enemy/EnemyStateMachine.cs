using UnityEngine;

namespace Game.Runtime.Enemy
{
    public class EnemyStateMachine : MonoBehaviour
    {
        private EnemyState _state;
        public EnemyState State => this._state;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private EnemyCombatController enemyCombatController;
        public void SetState(EnemyState state)
        {
            state.enemyController = this.enemyController;
            state.enemyCombatController = this.enemyCombatController;
            state.enemyStateMachine = this;
            this._state = state;
            StartCoroutine(this._state.Start());
        }
    }
}