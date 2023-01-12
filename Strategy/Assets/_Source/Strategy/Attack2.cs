using UnityEngine;

namespace Strategy
{
    public class Attack2 : IAttackStrategy
    {
        private int id;

        public Attack2()
        {
            id = Animator.StringToHash("Attack2");
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(id);
        }
    }
}