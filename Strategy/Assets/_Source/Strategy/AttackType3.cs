using UnityEngine;

namespace Strategy
{
    public class AttackType3 : IAttackStrategy
    {
        public int ID { get; set; }

        public AttackType3(string triigerName)
        {
            ID = Animator.StringToHash(triigerName);
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(ID);
        }
    }
}