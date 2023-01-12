using UnityEngine;

namespace Strategy
{
    public class Attack1 : IAttackStrategy
    {
        private int id;

        public Attack1()
        {
            id = Animator.StringToHash("Attack1");
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(id);
        }
    }
}