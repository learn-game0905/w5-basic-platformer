using System.Collections;
using Game.Runtime.Stats.Character;
using UnityEngine;

namespace Game.Runtime.Enemy
{
    public class EnemyCombatController : CombatController
    {
        private EnemyStatsController _enemyStatsController;
        private EnemyStats Stats => this._enemyStatsController.Stats;
        private EnemyStateMachine _enemyStateMachine;
        private EnemyAnimationController _enemyAnimationController;
        [SerializeField] private EnemyDropItem dropItem;
        [SerializeField] private LayerMask hitLayer;
        [SerializeField] private Transform attackPoint;
    
        protected override void Start()
        {
            base.Start();
            this._enemyStatsController = GetComponent<EnemyStatsController>();
            this._enemyStateMachine = GetComponent<EnemyStateMachine>();
            this._enemyAnimationController = GetComponent<EnemyAnimationController>();

            this._enemyAnimationController.AddAttackEvent(Hit);
            this._enemyAnimationController.AddHurtEvent(EndTakenDamage);
        }

        public override void Hit()
        {
            Collider2D[] collider2Ds =
                Physics2D.OverlapCircleAll(this.attackPoint.position, this.Stats.attackRange, this.hitLayer);
            if (collider2Ds != null)
            {
                foreach (var collider2D in collider2Ds)
                {
                    CombatController combatController = ColliderDictionary.CombatControllers[collider2D];
                    if (combatController != null)
                    {
                        combatController.TakenDamage(this.Stats.attack);
                    }
                }
            }
        }

        private float _damage;

        public override void TakenDamage(float damage)
        {
            this._damage = damage;
            StartCoroutine(this._enemyStateMachine.State.TakenDamage());
        }

        public void ActionTakenDamage()
        {
            this._enemyAnimationController.Hurt();
            if (this._enemyStatsController.TakenDamage(this._damage))
            {
                Death();
            }
        }

        private void EndTakenDamage()
        {
            this._enemyStateMachine.SetState(new IdleState());
        }

        public override void Death()
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<EnemyController>().enabled = false;
            this._enemyAnimationController.Death();
            EnemyManager.Instance.Death(gameObject);
            StartCoroutine(Disappear());
        }

        private IEnumerator Disappear()
        {
            yield return new WaitForSeconds(1.5f);
            dropItem.Drop();
            Destroy(this.gameObject);
        }
    }
}