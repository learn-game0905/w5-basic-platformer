using Game.Runtime.Input_System;
using Game.Runtime.Stats.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Runtime.Character
{
    [RequireComponent(typeof(Rigidbody2D),
        typeof(CharacterStateMachine),
        typeof(CharacterAnimationController))]
    public class CharacterController : MonoBehaviour
    {
        #region Actions

        private InputAction _moveAction;
        private InputAction _attackAction;
        private CustomInputSystem _playerInputs;

        #endregion
        [SerializeField] private Transform gfx;
        private Rigidbody2D rb;
        private CharacterStatsController _characterStatsController;
        private CharacterStats Stats => this._characterStatsController.Stats;
        private CharacterStateMachine _characterStateMachine;
        private CharacterAnimationController _characterAnimationController;

        private Vector2 _moveDir;

        public bool block;

        private void Start()
        {
            InitialActions();
            rb = GetComponent<Rigidbody2D>();
            _characterStatsController = GetComponent<CharacterStatsController>();
            _characterStateMachine = GetComponent<CharacterStateMachine>();
            _characterAnimationController = GetComponent<CharacterAnimationController>();
            _characterStateMachine.SetState(new IdleState());
        }

        private void InitialActions()
        {
            _playerInputs = new CustomInputSystem();
            _moveAction = _playerInputs.Player.Move;
            _moveAction.Enable();
            _attackAction = _playerInputs.Player.Attack;
            _attackAction.Enable();
        }

        public void Idle()
        {
            _characterAnimationController.Idle();
            Vector3 velocity = this.rb.velocity;
            velocity.x = 0;
            this.rb.velocity = velocity;
        }

        public void Move()
        {
            Vector3 velocity = this.rb.velocity;
            _characterAnimationController.Walk();
            this.gfx.localScale = new Vector3(this._moveDir.x, 1, 1);
            velocity.x = this._moveDir.x * Stats.moveSpeed;
            this.rb.velocity = velocity;
        }

        public float Attack()
        {
            _characterAnimationController.Attack(1);
            return CharacterAnimation.Attack1Duration;
        }

        private void Update()
        {
            if (block) return;
            this._moveDir = this._moveAction.ReadValue<Vector2>();
            if (_attackAction.IsPressed())
            {
                StartCoroutine(_characterStateMachine.State.Attack());
            }

            StartCoroutine(this._moveDir.magnitude > 0
                ? this._characterStateMachine.State.Walk()
                : this._characterStateMachine.State.Idle());
        }
    }
}