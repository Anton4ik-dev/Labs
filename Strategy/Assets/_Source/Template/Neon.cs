using UnityEngine;

namespace Template
{
    public class Neon : ABaseEnemy
    {
        private readonly int _id;

        public Neon(Animator animator, string triigerName)
        {
            _id = Animator.StringToHash(triigerName);
            Animator = animator;
        }

        public override void DoAttack()
        {
            Animator.SetTrigger(_id);
        }
    }
}