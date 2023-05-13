using UnityEngine;

namespace Strategy
{
    public class AttackType1 : IAttackStrategy
    {
        private readonly int _id;

        public AttackType1(string trigerName)
        {
            _id = Animator.StringToHash(trigerName);
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(_id);
        }
    }
}