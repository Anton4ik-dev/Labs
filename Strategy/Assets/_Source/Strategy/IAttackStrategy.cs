using UnityEngine;

namespace Strategy
{
    public interface IAttackStrategy
    {
        int ID { get; set; }
        void DoAttack(Animator animator);
    }
}