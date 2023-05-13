using UnityEngine;

namespace Strategy
{
    public interface IAttackStrategy
    {
        public void DoAttack(Animator animator);
    }
}