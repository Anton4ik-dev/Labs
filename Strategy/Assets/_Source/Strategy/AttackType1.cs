using UnityEngine;

namespace Strategy
{
    public class AttackType1 : IAttackStrategy
    {
        public int ID { get; set; }

        public AttackType1(string triigerName)
        {
            ID = Animator.StringToHash(triigerName);
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(ID);
        }
    }
}