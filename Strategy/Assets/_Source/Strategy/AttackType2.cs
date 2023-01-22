using UnityEngine;

namespace Strategy
{
    public class AttackType2 : IAttackStrategy
    {
        public int ID { get; set; }

        public AttackType2(string triigerName)
        {
            ID = Animator.StringToHash(triigerName);
        }

        public void DoAttack(Animator animator)
        {
            animator.SetTrigger(ID);
        }
    }
}