using UnityEngine;

namespace Template
{
    public class Neon : ABaseEnemy
    {
        public override Animator Animator { get; set; }
        public override int ID { get; set; }

        public Neon(Animator animator, string triigerName)
        {
            ID = Animator.StringToHash(triigerName);
            Animator = animator;
        }

        public override void DoAttack()
        {
            Animator.SetTrigger(ID);
        }
    }
}