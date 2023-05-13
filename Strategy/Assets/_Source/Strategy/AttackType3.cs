using UnityEngine;

namespace Strategy
{
    public class AttackType3 : IAttackStrategy
    {
        private readonly int _id;

        public AttackType3(string trigerName)
        {
            _id = Animator.StringToHash(trigerName);
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(_id);
        }
    }
}