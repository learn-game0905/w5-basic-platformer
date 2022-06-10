
using System.Collections;
using Game.Runtime.Stats.Character;
using UnityEngine;

namespace Game.Runtime.Character
{
    public class CharacterCombatController : CombatController
    {
        private CharacterStatsController _characterStatsController;
        private CharacterStats Stats => this._characterStatsController.Stats;
        private CharacterStateMachine _characterStateMachine;
        private CharacterAnimationController _characterAnimationController;
        [SerializeField] private LayerMask hitLayer;
        [SerializeField] private Transform attackPoint;
        
        protected override void Start()
        {
            base.Start();
            _characterStatsController = GetComponent<CharacterStatsController>();
            _characterStateMachine = GetComponent<CharacterStateMachine>();
            _characterAnimationController = GetComponent<CharacterAnimationController>();
            
            this._characterAnimationController.AddAttackEvent(Hit);
            this._characterAnimationController.AddHurtEvent(EndTakenDamage);
        }
        public override void Hit()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(this.attackPoint.position, Stats.attackRange, this.hitLayer);
            if (collider2Ds != null)
            {
                foreach (var collider2D in collider2Ds)
                {
                    CombatController combatController = ColliderDictionary.CombatControllers[collider2D];
                    if (combatController != null)
                    {
                        combatController.TakenDamage(Stats.attack);
                    }
                }
            }
        }

        private float _damage;
        public override void TakenDamage(float damage)
        {
            _damage = damage;
            StartCoroutine(this._characterStateMachine.State.TakenDamage());
        }

        public void ActionTakenDamage()
        {
            this._characterAnimationController.Hurt();
            if (this._characterStatsController.TakenDamage(_damage))
            {
                Death();
            }
        }
        private void EndTakenDamage()
        {
            this._characterStateMachine.SetState(new IdleState());
        }

        private void Death()
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<CharacterController>().enabled = false;
            this._characterAnimationController.Death();
            StateManager.Instance.Lose();
            StartCoroutine(Disappear());
        }

        private IEnumerator Disappear()
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }
    }
}
