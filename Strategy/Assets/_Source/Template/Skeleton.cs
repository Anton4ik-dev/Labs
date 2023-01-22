using UnityEngine;

namespace Template
{
    public class Skeleton : ABaseEnemy
    {
        public override Animator Animator { get; set; }
        public override int ID { get; set; }

        public Skeleton(Animator animator, string triigerName)
        {
            ID = Animator.StringToHash(triigerName);
            Animator = animator;
        }

        public override void DoAttack()
        {

        }
    }
}