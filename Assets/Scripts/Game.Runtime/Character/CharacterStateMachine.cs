using UnityEngine;

namespace Game.Runtime.Character
{
    public class CharacterStateMachine : MonoBehaviour
    {
        private CharacterState _state;
        public CharacterState State => this._state;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private CharacterCombatController characterCombatController;
        public void SetState(CharacterState state)
        {
            state.characterController = characterController;
            state.characterCombatController = characterCombatController;
            state.characterStateMachine = this;
            _state = state;
            StartCoroutine(_state.Start());
        }
    }
}