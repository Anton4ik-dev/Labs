using UnityEngine;

namespace Strategy
{
    public class AttackType2 : IAttackStrategy
    {
        private readonly int _id;

        public AttackType2(string trigerName)
        {
            _id = Animator.StringToHash(trigerName);
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(_id);
        }
    }
}