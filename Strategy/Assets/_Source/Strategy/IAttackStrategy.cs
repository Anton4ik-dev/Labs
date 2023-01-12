using UnityEngine;

namespace Strategy
{
    public interface IAttackStrategy
    {
        void DoAttack(Animator animator);
    }
}