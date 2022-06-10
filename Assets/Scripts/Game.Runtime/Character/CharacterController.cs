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
        private InputAction _jumpAction;
        private CustomInputSystem _playerInputs;

        #endregion

        [SerializeField] private Transform gfx;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private BoxCollider2D boxCollider2D;
        private Rigidbody2D rb;
        private CharacterStatsController _characterStatsController;
        private CharacterStats Stats => _characterStatsController.Stats;
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


        private void FixedUpdate()
        {
            if (block) return;

            _moveDir = _moveAction.ReadValue<Vector2>();

            StartCoroutine(this._moveDir.magnitude > 0 ? _characterStateMachine.State.Walk() :
                IsGround() ? _characterStateMachine.State.Idle() : _characterStateMachine.State.Jump());

            if (_attackAction.IsPressed())
            {
                StartCoroutine(_characterStateMachine.State.Attack());
            }

            if (this._jumpAction.IsPressed() && IsGround())
            {
                StartCoroutine(_characterStateMachine.State.Jump());
            }


            //
            // if (!IsGround())
            // {
            //     this._characterAnimationController.Jump();
            // }
        }

        private void InitialActions()
        {
            _playerInputs = new CustomInputSystem();
            _moveAction = _playerInputs.Player.Move;
            _moveAction.Enable();
            _attackAction = _playerInputs.Player.Attack;
            _attackAction.Enable();
            _jumpAction = _playerInputs.Player.Jump;
            _jumpAction.Enable();
        }

        public void Idle()
        {
            _characterAnimationController.Idle();
            Vector3 velocity = rb.velocity;
            velocity.x = 0;
            rb.velocity = velocity;
        }

        public void Move()
        {
            Vector3 velocity = rb.velocity;
            _characterAnimationController.Walk();
            gfx.localScale = new Vector3(_moveDir.x, 1, 1);
            velocity.x = _moveDir.x * Stats.moveSpeed;
            rb.velocity = velocity;
        }

        public void Attack()
        {
            _characterAnimationController.Attack(1, Stats.attackSpeed);
        }

        public bool IsGround()
        {
            var bounds = this.boxCollider2D.bounds;
            bounds.size = new Vector2(bounds.size.x - .1f, bounds.size.y);
            return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, this.groundMask);
        }

        public void Jump()
        {
            this._characterAnimationController.Jump();
            if (!IsGround()) return;
            var velocity = this.rb.velocity;
            velocity.y += Stats.jumpHeight;
            rb.velocity = velocity;
        }
    }
}