using System;
using UnityEngine;

namespace Game.Runtime.Enemy
{
    public static class EnemyAnimation
    {
        public static readonly string Idle = "Idle"; 
        public static readonly float IdleDuration = 0.5f; 
        public static readonly string Walk = "Walk";
        public static readonly float WalkDuration = 0.833f;
        public static readonly string Attack1 = "Attack_1";
        public static readonly float Attack1Duration = 2f;
        public static readonly string Attack2 = "Attack_2"; 
        public static readonly float Attack2Duration = 0.833f;
        public static readonly string Attack3 = "Attack_3"; 
        public static readonly float Attack3Duration = 0.833f;
        public static readonly string Hurt = "Hurt";
        public static readonly float HurtDuration = 1f;
        public static readonly string Death = "Death";
        public static readonly float DeathDuration = 0.833f;
    }
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private EnemyAnimationEventController enemyAnimationEventController;
        public void Idle()
        {
            this.animator.ResetTrigger(EnemyAnimation.Walk);
            this.animator.SetTrigger(EnemyAnimation.Idle);
        }
        public void Walk()
        {
            this.animator.SetTrigger(EnemyAnimation.Walk);
        }
        
        public void Attack(int type)
        {
            string attackAnimation;
            switch (type)
            {
                case 1:
                {
                    attackAnimation = EnemyAnimation.Attack1;
                    break;
                }
                case 2:
                {
                    attackAnimation = EnemyAnimation.Attack2;
                    break;
                }
                case 3:
                {
                    attackAnimation = EnemyAnimation.Attack3;
                    break;
                }
                default:
                {
                    return;
                }
            }
            this.animator.SetTrigger(attackAnimation);
        }

        public void Hurt()
        {
            this.animator.SetTrigger(EnemyAnimation.Hurt);
        }

        public void Death()
        {
            this.animator.SetTrigger(EnemyAnimation.Death);
        }
        public void AddAttackEvent(Action attackEvent)
        {
            this.enemyAnimationEventController.AddAttackEvent(attackEvent);
        }

        public void AddHurtEvent(Action hurtEvent)
        {
            this.enemyAnimationEventController.AddHurtEvent(hurtEvent);
        }
    }
}