using UnityEngine;

namespace Strategy
{
    public class Attack3 : IAttackStrategy
    {
        private int id;

        public Attack3()
        {
            id = Animator.StringToHash("Attack3");
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(id);
        }
    }
}