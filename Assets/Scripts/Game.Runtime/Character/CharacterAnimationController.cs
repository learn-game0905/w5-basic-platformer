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
        public static readonly string Jump1 = "Jump_1";
        public static readonly float Jump1Duration = 0.333f;

        public static readonly string[] ListAnimation = {Idle, Walk, Attack1, Attack2, Attack3, Hurt, Death, Jump1};
    }

    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterAnimationEventController characterAnimationEventController;

        [SerializeField]
        private string currentAnimation = "";

        private void SetTrigger(string _anmation, float speed)
        {
            if (this.currentAnimation.Equals(_anmation)) return;
            this.currentAnimation = _anmation;
            ResetAnimations(new[] {_anmation});
            this.animator.SetTrigger(_anmation);
            this.animator.speed = speed;
        }

        private bool isIgnoreAnimation(string _animation, string[] ignoreAnimations)
        {
            foreach (var ignoreAnimation in ignoreAnimations)
            {
                if (_animation.Equals(ignoreAnimation)) return true;
            }

            return false;
        }

        private void ResetAnimations(string[] ignoreAnimations)
        {
            Action resetTriggers = () => { };
            foreach (var _animation in CharacterAnimation.ListAnimation)
            {
                if (isIgnoreAnimation(_animation, ignoreAnimations)) continue;
                resetTriggers += () => {
                    this.animator.ResetTrigger(_animation);
                };
            }

            resetTriggers?.Invoke();
        }

        public void Idle()
        {
            SetTrigger(CharacterAnimation.Idle, 1);
        }

        public void Walk()
        {
            SetTrigger(CharacterAnimation.Walk, 1);
        }

        public void Attack(int type, float attackSpeed)
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

            SetTrigger(attackAnimation, attackSpeed);
        }

        public void Hurt()
        {
            SetTrigger(CharacterAnimation.Hurt, 1);
        }

        public void Death()
        {
            SetTrigger(CharacterAnimation.Death, 1);
        }

        public void Jump()
        {
            SetTrigger(CharacterAnimation.Jump1, 1);
        }

        public void AddAttackEvent(Action attackEvent)
        {
            characterAnimationEventController.AddAttackEvent(attackEvent);
        }

        public void AddHurtEvent(Action hurtEvent)
        {
            this.characterAnimationEventController.AddHurtEvent(hurtEvent);
        }
        
        public void AddEndAttackEvent(Action endAttackEvent)
        {
            this.characterAnimationEventController.AddEndAttackEvent(endAttackEvent);
        }
    }
}