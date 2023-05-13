using UnityEngine;

namespace Template
{
    public class Skeleton : ABaseEnemy
    {
        private readonly int _id;

        public Skeleton(Animator animator, string triigerName)
        {
            _id = Animator.StringToHash(triigerName);
            Animator = animator;
        }

        public override void DoAttack()
        {

        }
    }
}