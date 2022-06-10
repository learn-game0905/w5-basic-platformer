using System;
using Game.Runtime.Input_System;
using Game.Runtime.Stats.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Runtime.Enemy
{
    [RequireComponent(typeof(Rigidbody2D),
        typeof(EnemyStateMachine),
        typeof(EnemyAnimationController))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform gfx;
        private Rigidbody2D rb;
        private EnemyStatsController _enemyStatsController;
        private EnemyStats Stats => this._enemyStatsController.Stats;
        private EnemyStateMachine _enemyStateMachine;
        private EnemyAnimationController _enemyAnimationController;

        private Vector2 _moveDir;

        public bool block;

        [SerializeField] private Transform attackPoint;
        [SerializeField] private LayerMask playerMask;
        [SerializeField] private Transform target;

        private void Start()
        {
            this.rb = GetComponent<Rigidbody2D>();
            this._enemyStatsController = GetComponent<EnemyStatsController>();
            this._enemyStateMachine = GetComponent<EnemyStateMachine>();
            this._enemyAnimationController = GetComponent<EnemyAnimationController>();
            this._enemyStateMachine.SetState(new IdleState());
        }

        private void Update()
        {
            FollowTarget();
        }

        public void Idle()
        {
            this._enemyAnimationController.Idle();
            Vector3 velocity = this.rb.velocity;
            velocity.x = 0;
            this.rb.velocity = velocity;
        }

        public void Move()
        {
            Vector3 velocity = this.rb.velocity;
            float flipX = this.gfx.localScale.x;
            if (this._moveDir.x > 0)
            {
                flipX = 1;
            }
            else
            {
                if (this._moveDir.x < 0)
                {
                    flipX = -1;
                }
            }

            this._enemyAnimationController.Walk();
            this.gfx.localScale = new Vector3(flipX, 1, 1);
            velocity.x = this._moveDir.x * this.Stats.moveSpeed;
            this.rb.velocity = velocity;
        }

        public float Attack()
        {
            this._enemyAnimationController.Attack(1);
            return EnemyAnimation.Attack1Duration;
        }

        private Transform CastTarget()
        {
            Collider2D[] collider2Ds =
                Physics2D.OverlapCircleAll(transform.position, Stats.followRange, this.playerMask);
            if (collider2Ds == null) return null;
            Transform minTarget = null;
            float minDistance = float.MaxValue;
            foreach (var collider2D in collider2Ds)
            {
                float distance = Vector2.Distance(transform.position, collider2D.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minTarget = collider2D.transform;
                }
            }

            return minTarget;
        }

        private void FollowTarget()
        {
            this.target = CastTarget();
            if (this.target == null)
            {
                StartCoroutine(this._enemyStateMachine.State.Idle());
                return;
            }
            Collider2D playerCollider = Physics2D.OverlapCircle(this.attackPoint.position, Stats.attackRange, this.playerMask);
            // float distance = Vector2.Distance(this.target.position, this.attackPoint.position);
            if (playerCollider)
            {
                StartCoroutine(this._enemyStateMachine.State.Attack());
                return;
            }

            this._moveDir = (this.target.position - this.transform.position).normalized;
            StartCoroutine(this._enemyStateMachine.State.Walk());
        }
    }
}