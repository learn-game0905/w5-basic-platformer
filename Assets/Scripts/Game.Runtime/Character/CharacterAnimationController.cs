using System;
using UnityEngine;

namespace Game.Runtime.Character
{
    public static class CharacterAnimation
    {
        public static readonly string Idle = "Idle"; 
        public static readonly float IdleDuration = 0.5f; 
        public static readonly string Walk = "Walk";
        public static readonly float WalkDuration = 0.833f;
        public static readonly string Attack1 = "Attack_1";
        public static readonly float Attack1Duration = 0.633f;
        public static readonly string Attack2 = "Attack_2"; 
        public static readonly float Attack2Duration = 0.833f;
        public static readonly string Attack3 = "Attack_3"; 
        public static readonly float Attack3Duration = 0.833f;
        public static readonly string Hurt = "Hurt";
        public static readonly float HurtDuration = 0.333f;
        public static readonly string Death = "Death";
        public static readonly float DeathDuration = 0.833f;
    }
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterAnimationEventController characterAnimationEventController;
        public void Idle()
        {
            this.animator.ResetTrigger(CharacterAnimation.Walk);
            this.animator.SetTrigger(CharacterAnimation.Idle);
        }
        public void Walk()
        {
            this.animator.SetTrigger(CharacterAnimation.Walk);
        }
        
        public void Attack(int type)
        {
            string attackAnimation;
            switch (type)
            {
                case 1:
                {
                    attackAnimation = CharacterAnimation.Attack1;
                    break;
                }
                case 2:
                {
                    attackAnimation = CharacterAnimation.Attack2;
                    break;
                }
                case 3:
                {
                    attackAnimation = CharacterAnimation.Attack3;
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
            this.animator.SetTrigger(CharacterAnimation.Hurt);
        }

        public void Death()
        {
            this.animator.SetTrigger(CharacterAnimation.Death);
        }
        public void AddAttackEvent(Action attackEvent)
        {
            characterAnimationEventController.AddAttackEvent(attackEvent);
        }

        public void AddHurtEvent(Action hurtEvent)
        {
            this.characterAnimationEventController.AddHurtEvent(hurtEvent);
        }
    }
}